using System.Threading.Tasks;

namespace XMG.ChildGame
{
	public interface IAsyncCommand
	{
		Task Execute();
	}
}