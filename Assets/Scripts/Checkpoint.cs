using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour {

	public UnityEvent[] events;
	private bool activated = false;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!activated && col.CompareTag("Player"))
		{
			GameManager.GM.CheckpointReached (this.gameObject);
			foreach (var ev in events) {
				ev.Invoke ();
			}
			activated = true;
		}
	}
}
