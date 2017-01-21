using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	private Animator animator;
	private int animOpenHash;
	private int animCloseHash;

	void Start()
	{
		animOpenHash = Animator.StringToHash ("Open");
		animCloseHash = Animator.StringToHash ("Close");
		animator = GetComponent<Animator> ();
	}

	public void OpenTrap(bool isOpen)
	{
		animator.SetTrigger (isOpen ? animOpenHash : animCloseHash);
	}
}
