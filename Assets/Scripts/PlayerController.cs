using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Player controller.
/// Capable of climbing and using objects
/// </summary>
public class PlayerController : BasicController {

	public enum ePlayerState
	{ ALIVE, DEAD, CLIMBING }

	public ePlayerState PlayerState
	{ get; set; }

	private int animClimb;
	private int animUse;

	protected override void Awake ()
	{
		base.Awake ();

		PlayerState = ePlayerState.ALIVE;
		animClimb = Animator.StringToHash ("isClimbing");
		animUse = Animator.StringToHash ("Use");
	}

	protected override void FixedUpdate ()
	{
		if (PlayerState == ePlayerState.CLIMBING)
			return;
		base.FixedUpdate ();
		if (Input.GetButtonDown("Climb"))
		{
			Climb ();
		}
		if (Input.GetButtonDown("Use"))
		{
			Use ();
		}
	}

	bool CanClimb(out GameObject ladder)
	{
		ladder = null;
		RaycastHit2D[] rh = Physics2D.RaycastAll(transform.position, transform.right * 0.2f, 0.9f);
		Debug.DrawRay (transform.position, transform.right, Color.red);
		foreach (RaycastHit2D r in rh)
		{
			if (r.transform.CompareTag("Ladder"))
			{
				ladder = r.transform.gameObject;
				break;
			}
		}
		return IsGrounded && ladder != null;
	}

	/// <summary>
	/// Climb a ladder.
	/// </summary>
	bool Climb()
	{
		GameObject ladder;

		if (CanClimb(out ladder))
		{
			return ladder.GetComponent<Ladder> ().UseLadder (this);
		}
		return false;
	}

	/// <summary>
	/// Use a selectable.
	/// </summary>
	bool Use()
	{
		return false;
	}
}