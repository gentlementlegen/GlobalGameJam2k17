using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalArtifact : AArtifact {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnActivated()
	{
		GameManager.GM.StopAllCoroutines ();
		StartCoroutine (GameManager.GM.ChangeWorldCoroutine ());
	}

	public override void OnDisabled()
	{
		GameManager.GM.StopAllCoroutines();
		StartCoroutine (GameManager.GM.ChangeWorldCoroutine (-1));
	}
}
