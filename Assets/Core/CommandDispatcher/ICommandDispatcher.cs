using System.Collections;
using System.Threading.Tasks;

namespace XMG.ChildGame
{
	public interface ICommandDispatcher
	{
		void Execute(ICommand command);
		Task ExecuteAsync(IAsyncCommand command);
		IEnumerable ExecuteYield(IYieldCommand command);
		void StopAll();
	}
}