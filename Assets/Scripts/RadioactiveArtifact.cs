using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveArtifact : AArtifact {

	[Header("Wave")]
	[SerializeField] private float maxRange = 100f;
	[SerializeField] private float fireRate = 1f;

	[Header("Power")]
	[SerializeField] private float powerLoad = 100f;

	private float lastShoot;

	// Use this for initialization
	void Start () {
		lastShoot = -fireRate;
	}
	
	public override void OnActivated ()
	{
		Activate (eActivation.STOPED);
		if (Time.time - lastShoot < fireRate)
			return;
		lastShoot = Time.time;
		StartCoroutine (Propagate());
	}

	public IEnumerator Propagate()
	{
		CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D> ();

		collider.isTrigger = true;
		for (float i = 0; i < maxRange; ++i) {
			collider.radius = i;
			yield return new WaitForSeconds (0.1f);
		}
		Destroy (collider);
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Energized") {
			Debug.Log ("Load");
			AEnergizedObject	obj = collider.gameObject.GetComponent<AEnergizedObject> ();

			if (obj)
				obj.Load (powerLoad);
		}
	}
}
