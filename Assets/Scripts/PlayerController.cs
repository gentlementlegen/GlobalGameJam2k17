﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

    GameObject item;

	[SerializeField]private Image	itemIco;

	protected override void Awake ()
	{
		base.Awake ();

		PlayerState = ePlayerState.ALIVE;
		animClimb = Animator.StringToHash ("isClimbing");
		animUse = Animator.StringToHash ("Use");
	}

	protected override void FixedUpdate ()
	{
		if (PlayerState != ePlayerState.ALIVE)
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
        Collider2D[] detectObjects = Physics2D.OverlapCircleAll(transform.position, 0.5f);

		Debug.DrawLine(transform.position, transform.position + transform.right * 0.5f);

        foreach(Collider2D obj in detectObjects)
        {
			IActivable composantActivable = obj.gameObject.GetComponent<IActivable>();

			if (composantActivable != null)
            {
				if (composantActivable.IsActivated ())
					composantActivable.Activate (eActivation.STOPED);
				else
                	composantActivable.Activate();
            }
        }
		return false;
	}


	public void StartClimbing()
	{
		PlayerState = PlayerController.ePlayerState.CLIMBING;
		animator.SetBool (animClimb, true);
//		GetComponent<Rigidbody2D> ().simulated = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
	}

	public void StopClimbing()
	{
		PlayerState = PlayerController.ePlayerState.ALIVE;
		animator.SetBool (animClimb, false);
//		GetComponent<Rigidbody2D> ().simulated = true;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item" && Item == null)
        {
            collision.gameObject.SetActive(false);
			if (itemIco != null) {
				itemIco.sprite = collision.gameObject.GetComponent<SpriteRenderer> ().sprite;
				itemIco.color = Color.white;
			}
            Item = collision.gameObject;
        }
    }

	protected override void Attack ()
	{
	}

	/// <summary>
	/// Kills the player.
	/// </summary>
	new public void Die()
	{
		GameManager.GM.Die ();
	}

    public GameObject Item
    {
        get { return item; }
        set { item = value; }
    }

    void ConsumeItem()
    {
        Destroy(Item);
    }
}