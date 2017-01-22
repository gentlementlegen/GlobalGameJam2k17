using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnergizedObject {
	void PoweredUpdate();
	void OnBatteryEmpty();
	void Load (float toFeed);
	float Capacity { get; }
}

public abstract class AEnergizedObject : MonoBehaviour, IEnergizedObject {

	[SerializeField] private float consumption = 0.1f;
	[SerializeField] private float capacity = 100f;

	private float _energy = 0f;
	
	// Update is called once per frame
	void Update () {
		if (_energy > 0) {
			PoweredUpdate ();
			_energy -= consumption * Time.deltaTime;
			Debug.Log (_energy);
			if (_energy <= 0)
				OnBatteryEmpty ();
		}
	}

	public abstract void PoweredUpdate();
	public virtual void OnBatteryEmpty(){}

	public void Load(float toFeed)
	{
		_energy += toFeed;
		if (_energy > capacity)
			_energy = capacity;
	}

	public float Capacity{
		get { return capacity; }
	}
}
