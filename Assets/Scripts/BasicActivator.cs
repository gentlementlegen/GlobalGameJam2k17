using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicActivator : MonoBehaviour {

	public AArtifact	activable = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			activable.Activate();
		} else if (Input.GetKey (KeyCode.B)) {
			activable.Activate (eActivation.STOPED);
		}
	}
}
