using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABaseLevier : AActivable {

	private GameObject levier = null;

	[SerializeField] private Transform attach;

	public abstract void Activated ();
	public abstract void Disabled ();

	public override void OnActivated()
	{
		if (levier != null) {
			levier.transform.RotateAround (attach.position, -Vector3.back, 90f);// (new Vector3 (0f, 0f, 90f));
			Activated ();
			return;
		}
		
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (player != null) {
			PlayerController	ctrl = player.GetComponent<PlayerController> ();

			if (ctrl != null) {
				GameObject item = ctrl.Item;

				if (item != null && item.name == "Levier") {
					levier = item;
					levier.transform.position = attach.position;
					levier.gameObject.SetActive (true);
					levier.transform.rotation.Set(0f, 0f, 0f, levier.transform.rotation.w);
					levier.transform.RotateAround (attach.position, -Vector3.back, 45f);// Rotate (new Vector3 (0f, 0f, 45f));
					Activated ();
					//consume item
					return;
				}
			}
		}
		Activate (eActivation.STOPED);
	}

	public override void OnDisabled()
	{
		levier.transform.RotateAround (attach.position, -Vector3.back, -90f);// (new Vector3(0f, 0f, -90f));
		Disabled ();
	}

	public GameObject Levier {
		get { return levier; }
		set { levier = value; }
	}
}
