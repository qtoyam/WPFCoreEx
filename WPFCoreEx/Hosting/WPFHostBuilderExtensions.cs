using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WPFCoreEx.Hosting
{
	public static class WPFHostBuilderExtensions
	{
		public static IHostBuilder UseWPFLifetime(this IHostBuilder hostBuilder)
		{
			return hostBuilder.ConfigureServices(collection => collection.AddSingleton<IHostLifetime, WPFLifetime>());
		}

		public static IHostBuilder UseWPFLifetime(this IHostBuilder hostBuilder, Action<WPFLifetimeOptions> configureOptions)
		{
			return hostBuilder.ConfigureServices(collection =>
			{
				collection.AddSingleton<IHostLifetime, WPFLifetime>();
				collection.Configure(configureOptions);
			});
		}
	}
}
