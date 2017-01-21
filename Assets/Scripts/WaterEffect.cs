using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class WaterEffect : MonoBehaviour {

	/// <summary>
	/// Vortex is made of radius(x, y), angle (deg) and center(x, y)
	/// </summary>
	[System.Serializable]
	public struct VortexProperties
	{
		[HideInInspector] public Vector2 radius;
		[HideInInspector] public float angle;
		[HideInInspector] public Vector2 center;
		[HideInInspector] public Vector2 target;
		public Vortex vortex;
		[HideInInspector] public Vector2 currVel;
	}

	public VortexProperties[] _vortex;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < _vortex.Length; ++i)
		{
			_vortex[i].radius = _vortex[i].vortex.radius;
			_vortex[i].angle = _vortex[i].vortex.angle;
			_vortex[i].center = _vortex[i].vortex.center;
			StartCoroutine (MoveCoroutine());
		}
	}

	void Update()
	{
		for (int i = 0; i < _vortex.Length; ++i)
		{
			_vortex [i].vortex.center = Vector2.SmoothDamp (_vortex [i].vortex.center, _vortex [i].target, ref _vortex [i].currVel, Time.deltaTime, 0.1f, Time.deltaTime);
		}
	}

	IEnumerator MoveCoroutine()
	{
		for (;;)
		{
			for (int i = 0; i < _vortex.Length; ++i)
			{
				_vortex [i].target = Random.insideUnitCircle * 2 + _vortex [i].center;
			}
			yield return new WaitForSeconds (1f);
		}
	}

	public void UpdateEffectState()
	{
		for (int i = 0; i < _vortex.Length; ++i)
		{
			_vortex [i].vortex.enabled = (GameManager.GM.CurrentWorld == GameManager.World.OLD);
		}
	}
}
