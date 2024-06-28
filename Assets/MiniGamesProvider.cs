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
				{ MiniGameType.Dentist, InitMiniGame(miniGameDatas, MiniGameType.Dentist) }
			};
		}

		private IMiniGame InitMiniGame(MiniGameData[] miniGameDatas, MiniGameType miniGameType)
		{
			return new DentistMiniGame(miniGameDatas.First(data => data.GameType == miniGameType));
		}
	}
}