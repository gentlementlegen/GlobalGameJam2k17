using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TerrainBoundsChecker : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			col.GetComponent<PlayerController> ().Die ();
		}
	}
}
