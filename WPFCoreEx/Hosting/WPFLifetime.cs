using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace WPFCoreEx.Hosting
{
	internal class WPFLifetime : IHostLifetime, IDisposable
	{
		private CancellationTokenRegistration _applicationStartedRegistration;
		private CancellationTokenRegistration _applicationStoppingRegistration;

		private readonly IHostApplicationLifetime _hostApplicationLifetime;
		private readonly ILogger _logger;
		private readonly IHostEnvironment _hostEnvironment;
		private readonly HostOptions _hostOptions;
		private readonly WPFLifetimeOptions _wpfLifetimeOptions;

		private readonly ManualResetEvent _shutdownBlock = new(false);

		private int _disposedCount = 0;

		public WPFLifetime(IHostApplicationLifetime hostApplicationLifetime, IHostEnvironment hostEnvironment, IOptions<HostOptions> hostOptions, IOptions<WPFLifetimeOptions> wpfLifetimeOptions)
			: this(hostApplicationLifetime, hostEnvironment, hostOptions, wpfLifetimeOptions, NullLoggerFactory.Instance) { }

		public WPFLifetime(IHostApplicationLifetime hostApplicationLifetime, IHostEnvironment hostEnvironment, IOptions<HostOptions> hostOptions, IOptions<WPFLifetimeOptions> wpfLifetimeOptions, ILoggerFactory loggerFactory)
		{
			_hostApplicationLifetime = hostApplicationLifetime ?? throw new ArgumentNullException(nameof(hostApplicationLifetime));
			_logger = loggerFactory.CreateLogger(nameof(WPFLifetime));
			_hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
			_hostOptions = hostOptions?.Value ?? throw new ArgumentNullException(nameof(hostOptions));
			_wpfLifetimeOptions = wpfLifetimeOptions?.Value ?? throw new ArgumentNullException(nameof(wpfLifetimeOptions));
		}


		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

		public Task WaitForStartAsync(CancellationToken cancellationToken)
		{
			if (!_wpfLifetimeOptions.SuppressStatusMessages)
			{
				_applicationStartedRegistration = _hostApplicationLifetime.ApplicationStarted.Register(state =>
				{
					((WPFLifetime)state!).OnApplicationStarted();
				},
				this);
				_applicationStoppingRegistration = _hostApplicationLifetime.ApplicationStopping.Register(state =>
				{
					((WPFLifetime)state!).OnApplicationStopping();
				},
				this);
			}

			RegisterShutdownHandlers();

			return Task.CompletedTask;
		}

		private void OnApplicationStarted()
		{
			_logger.LogInformation("Application started.");
			_logger.LogInformation("Hosting environment: {envName}", _hostEnvironment.EnvironmentName);
			_logger.LogInformation("Content root path: {contentRoot}", _hostEnvironment.ContentRootPath);
			_logger.LogDebug("Shutdown timeout: {timeout}", _hostOptions.ShutdownTimeout);
		}

		private void OnApplicationStopping()
		{
			_logger.LogInformation("Application is stopping...");
		}

		private void RegisterShutdownHandlers()
		{
			AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
		}

		private void OnProcessExit(object? sender, EventArgs e)
		{
			try
			{
				_logger.LogInformation("Process exiting...");
				_hostApplicationLifetime.StopApplication();
				if (!_shutdownBlock.WaitOne(_hostOptions.ShutdownTimeout))
				{
					_logger.LogInformation("Waiting for the host to be disposed. Ensure all 'IHost' instances are wrapped in 'using' blocks. Ensure Application.Current.OnExit is not async.");
					if (!_shutdownBlock.WaitOne(_hostOptions.ShutdownTimeout))
					{
						_logger.LogCritical("Forcing exit.");
						this.Dispose();
						System.Environment.ExitCode = 0b1000_0000_0000_0000;
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Error while exiting process, message: {message}", ex.Message);
			}
			finally
			{
				_shutdownBlock.Close();
				AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;

				_logger.LogInformation("Process exited.");
			}
		}

		public void Dispose()
		{
			if (Interlocked.Increment(ref _disposedCount) == 1)
			{
				_logger.LogInformation("Disposing..");
				_applicationStartedRegistration.Dispose();
				_applicationStoppingRegistration.Dispose();
				_logger.LogInformation("Disposed.");
				_shutdownBlock.Set(); //let process exit without waiting.
			}
		}
	}
}
