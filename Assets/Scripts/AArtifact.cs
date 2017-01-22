using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AArtifact : AActivable {

	[Header ("Artifact")]
	[SerializeField] private Text _message = null;

	void Start()
	{
		if (_message)
			_message.enabled = false;
	}

	void FixedUpdate()
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll (transform.position, 0.5f + transform.localScale.x / 2f, transform.forward);
	
		Debug.DrawRay (transform.position, -transform.right * (0.5f + transform.localScale.x / 2f));
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
}
