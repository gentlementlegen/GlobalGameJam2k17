using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevier : ABaseLevier {

	[Header ("Effect")]
	[SerializeField] private GameObject toactivate;

	public override void Activated ()
	{
		IActivable	act = toactivate.GetComponent<IActivable> ();

		if (act != null) {
			act.Activate ();
		}
	}

	public override void Disabled ()
	{
		IActivable act = toactivate.GetComponent<IActivable> ();

		if (act != null) {
			act.Activate (eActivation.STOPED);
		}
	}
}
