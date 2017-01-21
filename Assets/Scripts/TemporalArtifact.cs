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
		StartCoroutine (GameManager.GM.ChangeWorldCoroutine ());
	}

	public override void OnDisabled()
	{
		StartCoroutine (GameManager.GM.ChangeWorldCoroutine (-1));
	}
}
