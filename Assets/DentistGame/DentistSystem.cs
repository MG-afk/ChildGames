﻿using XMG.ChildGame.Dentist.Tool;
using XMG.ChildGame.Dentist.WaitingRoom;
using XMG.ChildGame.DentistGame.Patient;

namespace XMG.ChildGame.Dentist
{
	public class DentistSystem
	{
		private readonly InputControls _input;
		private readonly PatientView.Factory _patientFactory;
		private readonly ToolSelectorView.Factory _toolSelectorViewFactory;

		public DentistSystem(
			InputControls input,
			PatientView.Factory patientFactory,
			ToolSelectorView.Factory toolSelectorFactory)
		{
			_input = input;
			_patientFactory = patientFactory;
			_toolSelectorViewFactory = toolSelectorFactory;
		}

		public void LoadPatient(PatientStartData data)
		{
			var patient = _patientFactory.Create();
			patient.Init(data);

			var toolSelector = _toolSelectorViewFactory.Create();
			toolSelector.transform.position = new UnityEngine.Vector3(0, -5, 0);
		}
	}
}
