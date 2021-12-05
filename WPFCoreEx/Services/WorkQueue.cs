using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace WPFCoreEx.Services
{
	public sealed class WorkQueue : IDisposable
	{
		private readonly BlockingCollection<Task> _workQueue = new();

		public WorkQueue()
		{
			Task.Factory.StartNew(Worker);
		}

		public Task Enqueue(Action work, CancellationToken cancellationToken = default)
		{
			var task = new Task(work, cancellationToken);
			_workQueue.Add(task, cancellationToken);
			return task;
		}

		private void Worker()
		{
			var ce = _workQueue.GetConsumingEnumerable();
			foreach(var work in ce)
			{
				try
				{
					if (!work.IsCanceled) work.RunSynchronously();
				}
				catch (InvalidOperationException) { }
			}
		}

		public void Dispose()
		{
			_workQueue.CompleteAdding();
			_workQueue.Dispose();
		}
	}
}
