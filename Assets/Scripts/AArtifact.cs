using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	[Header ("Artifact")]
	[SerializeField] private eActivation	_state = eActivation.STOPED;
	[SerializeField] private Text _message = null;

	protected eActivation State
	{
		get { return _state; }
		private set { _state = value; }
	}

	void Start()
	{
		if (_message)
			_message.enabled = false;
	}

	void FixedUpdate()
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, 2, transform.forward);
	
		foreach (RaycastHit2D hit in hits) {
			if (hit.collider.tag == "Player") {
				if (_message)
					_message.enabled = true;
				return;
			}
		}
		if (_message)
			_message.enabled = false;
	}

	//activate or disable the artifact
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
