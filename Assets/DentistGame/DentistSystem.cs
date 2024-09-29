using Dream.Core;
using XMG.ChildGame.Dentist.Tool;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.DentistGame.Patient;

namespace XMG.ChildGame.Dentist
{
	public class DentistSystem
	{
		private readonly IPresenterStageManager _presenterStageManager;

		public DentistSystem(IPresenterStageManager presenterStageManager)
		{
			_presenterStageManager = presenterStageManager;
		}

		public void LoadPatient(PatientStartData data)
		{
			//PASS the model :3
			var patient = _presenterStageManager.CreatePresenter<PatientPresneter, PatientView>();

			var toolSelector = _presenterStageManager.CreatePresenter<ToolSelectorPresenter, ToolSelectorView>();
		}
	}
}
