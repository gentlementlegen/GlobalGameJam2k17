using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : AEnergizedObject {

	[Header("Sprites")]
	[SerializeField] private Sprite On;
	[SerializeField] private Sprite Off;

	private bool enlighted = false;
	private SpriteRenderer	rend;

	void Start()
	{
		rend = GetComponent<SpriteRenderer> ();
		if (rend == null)
			rend = gameObject.AddComponent<SpriteRenderer> ();
	}

	public override void PoweredUpdate()
	{
		if (!enlighted) {
			rend.sprite = On;
			enlighted = true;
		}
	}

	public override void OnBatteryEmpty()
	{
		enlighted = false;
		rend.sprite = Off;
	}
}
