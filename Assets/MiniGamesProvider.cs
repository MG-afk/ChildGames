using System.Collections.Generic;
using System.Linq;

namespace XMG.ChildGame
{
	public sealed class MiniGamesProvider
	{
		private Dictionary<MiniGameType, IMiniGame> _gamesByType;

		public IReadOnlyDictionary<MiniGameType, IMiniGame> GamesByType => _gamesByType;

		public MiniGamesProvider(MiniGameData[] miniGameDatas)
		{
			_gamesByType = new()
			{
				{ MiniGameType.Dentist, InitMiniGame(miniGameDatas, MiniGameType.Dentist) },
				{ MiniGameType.Puzzle, InitMiniGame(miniGameDatas, MiniGameType.Puzzle) }
			};
		}

		private IMiniGame InitMiniGame(MiniGameData[] miniGameDatas, MiniGameType miniGameType)
		{
			var data = miniGameDatas.First(data => data.GameType == miniGameType);

			return miniGameType switch
			{
				MiniGameType.Dentist => new DentistMiniGame(data),
				MiniGameType.Puzzle => new PuzzleMiniGame(data),
				_ => null,
			};
		}
	}
}