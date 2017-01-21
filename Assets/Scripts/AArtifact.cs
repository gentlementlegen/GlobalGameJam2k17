using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eActivation
{
	ACTIVATED, STOPED
}

public interface IActivable {
	void Activate(eActivation state = eActivation.ACTIVATED);
	void OnActivated();
	void OnDisabled();
	bool IsActivated();
}

public abstract class AArtifact : MonoBehaviour, IActivable {

	private eActivation	_state = eActivation.STOPED;

	protected eActivation State
	{
		get { return _state; }
		private set { _state = value; }
	}

	void Start()
	{
		Activate (eActivation.ACTIVATED);
	}

	public void Activate(eActivation state = eActivation.ACTIVATED)
	{
		if (this.State == state)
			return;
		this.State = state;
		if (IsActivated())
			this.OnActivated ();
		else
			this.OnDisabled ();
	}

	public virtual void OnActivated (){}

	public virtual void OnDisabled (){}

	public bool IsActivated()
	{
		return this.State == eActivation.ACTIVATED;
	}
}
