namespace XMG.ChildGame
{
	public sealed class ResourcesSystem
	{
		private float _gold;

		public float Gold => _gold;

		public void EarnGold(float gold)
		{
			_gold += gold;
		}

		public bool TrySpendGold(float spend)
		{
			if (_gold > spend)
				return false;

			_gold -= spend;
			return true;
		}
	}
}