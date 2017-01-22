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

public abstract class AActivable : MonoBehaviour, IActivable {

	[Header("Activable")]
	[SerializeField] private eActivation	_state = eActivation.STOPED;
	[SerializeField] private float 			_actionRate = 0.5f;

	private float _lastAction = -0.5f;

	protected eActivation State
	{
		get { return _state; }
		private set { _state = value; }
	}

	//activate or disable the artifact
	public void Activate(eActivation state = eActivation.ACTIVATED)
	{
		if (this.State == state || Time.time - _lastAction < _actionRate)
			return;
		_lastAction = Time.time;
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
