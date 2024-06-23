using System;

namespace XMG.ChildGame.Dentist
{
	public class DentistSystem
	{
		private readonly InputControls _input;

		public DentistSystem(InputControls input)
		{
			_input = input;
		}
	}

	public class Mission
	{
		public event Action<bool> MissionAcomplished;
	}
}
