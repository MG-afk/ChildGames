using System.Collections;

namespace XMG.ChildGame
{
	public interface IYieldCommand
	{
		IEnumerable Execute();
	}
}