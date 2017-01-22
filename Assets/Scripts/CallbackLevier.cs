using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallbackLevier : ABaseLevier {

	[SerializeField]private UnityEvent	activate;
	[SerializeField]private UnityEvent	disable;

	public override void Activated ()
	{
		activate.Invoke ();
	}

	public override void Disabled ()
	{
		disable.Invoke ();
	}
}
