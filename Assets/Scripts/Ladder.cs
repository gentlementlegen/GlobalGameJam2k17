using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ladder script behaviour.
/// </summary>
public class Ladder : MonoBehaviour {

	private bool isClimbing = true;
	PlayerController currentPlayerClimbing = null;
	private Vector2 topPos;
	private Vector2 botPos;
	private Vector2 climbTarget;

	void Start()
	{
		topPos = new Vector2(transform.position.x, this.transform.position.y - GetComponent<SpriteRenderer> ().sprite.rect.height / 2f);
		botPos = new Vector2(transform.position.x, this.transform.position.y + GetComponent<SpriteRenderer> ().sprite.rect.height / 2f);
	}
	
	void FixedUpdate ()
	{
		if (isClimbing)
		{
			currentPlayerClimbing.transform.position = Vector3.MoveTowards(currentPlayerClimbing.transform.position, climbTarget, 0.2f);
		}
	}

	void StartClimbing()
	{
		
	}

	void StopClimbing()
	{
		currentPlayerClimbing = null;
		isClimbing = false;
	}

	public bool UseLadder(PlayerController pc)
	{
		if (isClimbing)
			return false;
		pc.PlayerState = PlayerController.ePlayerState.CLIMBING;
		currentPlayerClimbing = pc;
		GetClimbingTarget ();
		isClimbing = true;
		return true;
	}

	/// <summary>
	/// Gets the climbing target.
	/// </summary>
	void GetClimbingTarget()
	{
		climbTarget = (transform.position.y >= currentPlayerClimbing.transform.position.y) ? topPos : botPos;
	}
}
