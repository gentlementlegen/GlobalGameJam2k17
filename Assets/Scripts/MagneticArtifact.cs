using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticArtifact : AArtifact {

	public override void OnActivated()
	{
		GetComponent<PointEffector2D> ().enabled = true;
		GetComponent<CircleCollider2D> ().enabled = true;
	}

	public override void OnDisabled()
	{
		GetComponent<PointEffector2D> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
	}
}
