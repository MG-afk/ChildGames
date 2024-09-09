using System;
using XMG.ChildGame.Navigation;
using Zenject;

namespace XMG.ChildGame.Puzzle
{
	public class PuzzleGameStartup : IInitializable, IDisposable
	{
		private readonly NavigationView.Factory _navigationFactory;
		private readonly PuzzleView.Factory _puzzleFactory;

		public PuzzleGameStartup(
			NavigationView.Factory navigationFactory,
			PuzzleView.Factory puzzleFactory)
		{
			_navigationFactory = navigationFactory;
			_puzzleFactory = puzzleFactory;
		}

		public void Initialize()
		{
			_navigationFactory.Create();
			_puzzleFactory.Create();
		}

		public void Dispose()
		{
		}
	}
}
