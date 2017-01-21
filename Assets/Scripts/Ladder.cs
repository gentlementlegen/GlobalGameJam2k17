using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ladder script behaviour.
/// </summary>
public class Ladder : MonoBehaviour {

	[SerializeField] private float climbingSpeed = 10f;
	private bool isClimbing = false;
	PlayerController currentPlayerClimbing = null;
	private Vector2 climbTarget;

	[SerializeField] private Transform topPos;
	[SerializeField] private Transform botPos;
	
	void FixedUpdate ()
	{
		if (isClimbing && currentPlayerClimbing != null)
		{
			currentPlayerClimbing.transform.position = Vector3.MoveTowards(currentPlayerClimbing.transform.position, climbTarget, climbingSpeed * Time.deltaTime);
		}
	}

	void StartClimbing()
	{
		currentPlayerClimbing.transform.position = new Vector3 (climbTarget.x, currentPlayerClimbing.transform.position.y, currentPlayerClimbing.transform.position.z);
		isClimbing = true;
	}

	void StopClimbing()
	{
		currentPlayerClimbing = null;
		isClimbing = false;
		currentPlayerClimbing.StopClimbing ();
	}

	public bool UseLadder(PlayerController pc)
	{
		if (isClimbing)
			return false;
		pc.StartClimbing ();
		currentPlayerClimbing = pc;
		GetClimbingTarget ();
		StartClimbing ();
		return true;
	}

	/// <summary>
	/// Gets the climbing target.
	/// </summary>
	void GetClimbingTarget()
	{
		climbTarget = (transform.position.y >= currentPlayerClimbing.transform.position.y) ? topPos.position : botPos.position;
	}
}
