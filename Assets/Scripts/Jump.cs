using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	[SerializeField] private string groundTag = "Ground";
	private bool canJump = false;
	private bool landed = false;

	void OnTriggerStay2D(Collider2D col) {

		if (col.tag == groundTag) {
			canJump = true;
			landed = false;
		}
	}

	void OnTriggerExit2D(Collider2D col) {

		if (col.tag == groundTag) {
			canJump = false;
		}
	}

	void OnTriggerEnter2D( Collider2D col )
	{
		if ( col.tag == groundTag )
		{
			landed = true;
		}
	}

	public bool getCanJump() {
		return canJump;
	}

	public bool Landed
	{
		get { return landed ;}
	}
}