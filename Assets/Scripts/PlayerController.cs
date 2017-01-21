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

    GameObject Item;

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
		RaycastHit2D[] rh = Physics2D.RaycastAll(transform.position, transform.right * 0.1f, 0.9f);
		Debug.DrawRay (transform.position, transform.right, Color.red);
		foreach (RaycastHit2D r in rh)
		{
			if (r.transform.CompareTag("Ladder"))
			{
				ladder = r.transform.gameObject;
				break;
			}
		}
		if (ladder == null
			|| (!ladder.GetComponent<Ladder> ().isPointingRight && transform.localScale.x < 0)
			|| (ladder.GetComponent<Ladder> ().isPointingRight && transform.localScale.x > 0))
		{
			return false;
		}
		return IsGrounded;
	}

	/// <summary>
	/// Climb a ladder.
	/// </summary>
	bool Climb()
	{
		GameObject ladder;

		if (CanClimb(out ladder))
		{
			if (ladder.GetComponent<Ladder> ().UseLadder (this))
			{
				return true;
			}
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


	public void StartClimbing()
	{
		PlayerState = PlayerController.ePlayerState.CLIMBING;
		animator.SetBool (animClimb, true);
		GetComponent<Rigidbody2D> ().simulated = false;
	}

	public void StopClimbing()
	{
		PlayerState = PlayerController.ePlayerState.ALIVE;
		animator.SetBool (animClimb, false);
		GetComponent<Rigidbody2D> ().simulated = true;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item" && Item == null)
        {
            collision.gameObject.SetActive(false);
            Item = collision.gameObject;
        }

    }

}