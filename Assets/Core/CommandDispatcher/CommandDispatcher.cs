using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace XMG.ChildGame
{
	public class CommandDispatcher : ICommandDispatcher, IDisposable
	{
		public CancellationTokenSource _cancellationTokenSource = new();

		public void Execute(ICommand command)
		{
			command.Execute();
		}

		public Task ExecuteAsync(IAsyncCommand command)
		{
			var task = Task.Factory.StartNew(() => command.Execute(),
				_cancellationTokenSource.Token,
				TaskCreationOptions.None,
				TaskScheduler.FromCurrentSynchronizationContext());

			return task;
		}

		public IEnumerable ExecuteYield(IYieldCommand command)
		{
			return command.Execute();
		}

		public void StopAll()
		{
			if (_cancellationTokenSource.IsCancellationRequested)
				return;

			_cancellationTokenSource.Cancel();
			_cancellationTokenSource.Dispose();
			_cancellationTokenSource = new CancellationTokenSource();
		}

		public void Dispose()
		{
			_cancellationTokenSource.Dispose();
		}
	}
}
