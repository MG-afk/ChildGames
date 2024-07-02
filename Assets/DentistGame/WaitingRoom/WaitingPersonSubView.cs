using UnityEngine;

namespace XMG.ChildGame.Dentist.WaitingRoom
{
	public sealed class WaitingPersonSubView : MonoBehaviour
	{
		public PatientStartData Data { get; private set; }

		private void Start()
		{
			Data = new PatientStartData();

			for (int i = 0; i < 10; i++)
			{
				Data.teethData[i] = new ToothData()
				{
					Yellowness = Random.Range(0.01f, 1.00f)
				};
			}
		}
	}

	public sealed class PatientStartData
	{
		public ToothData[] teethData = new ToothData[10];
	}

	public sealed class ToothData
	{
		public float Yellowness;
	}
}