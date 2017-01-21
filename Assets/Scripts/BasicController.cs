using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BasicController : MonoBehaviour {

	public AudioClip [] sounds;
	protected AudioSource audioSource;

	public float jumpStrength = 0;
	public float horizontalStrength = 0;
	protected float attackDelay = 0.3f;
	private float scale;

	// Contient tous les binds pour chaque joueur
	protected Dictionary<string, string> keyBinds;
	private List<string> imputName;

	private int _playerID = 0;

	protected bool timerJump = false;
	protected GameObject jump;
	protected bool WallJump = false;

	protected Animator animator;
	protected int animAttackID;

	protected int animVerticalVel;
	protected int animHorizontalVel;
	private int animIsGrounded;
	private int animAttack;
	private int animDeath;
	private int animID;

	private float attackCurrentDelay;

	protected virtual void Awake () 
	{
		jump = this.transform.GetChild (0).gameObject;
		animator = this.GetComponent<Animator>();

		animVerticalVel = Animator.StringToHash( "VerticalVel" );
		animHorizontalVel = Animator.StringToHash( "HorizontalVel" );
		animIsGrounded = Animator.StringToHash( "isGrounded" );
		animAttack = Animator.StringToHash( "Attack" );
		animDeath = Animator.StringToHash( "Die" );
		animID = Animator.StringToHash( "AnimID" );

		attackCurrentDelay = 0;

		imputName = new List<string>();
		imputName.Add( "Fire1" );
		imputName.Add( "Jump" );
		imputName.Add( "Horizontal" );
		imputName.Add( "item_1" );
		imputName.Add( "item_2" );
		imputName.Add( "item_3" );
		imputName.Add( "Dash" );
		// Les binds sont gérés par le game manager

		// Player ID est initialisé dans les classes enfant
		scale = this.transform.localScale.x;

		audioSource = this.GetComponent<AudioSource>();

		IsDead = false;
	}

	protected virtual void Update()
	{
		if ( attackCurrentDelay > 0 )
			attackCurrentDelay -= Time.deltaTime;
	}

	protected virtual void FixedUpdate () {

		if ( IsDead )
			return;

		#region Cette région s'occupe de la gestion des animations
		if ( jump.GetComponent<Jump>().getCanJump() )
		{
			animator.SetBool( animIsGrounded, true );
		}
		else
		{
			animator.SetBool( animIsGrounded, false );
		}

		animator.SetFloat( animHorizontalVel, Input.GetAxis("Horizontal") );
		animator.SetFloat( animVerticalVel, -Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y ));
//		animator.SetFloat( animVerticalVel, this.GetComponent<Rigidbody2D>().velocity.y );

		#endregion

		if (jump.GetComponent<Jump>().getCanJump() && Input.GetAxis("Jump") != 0 && !timerJump) {
			StartCoroutine("timer_jump");
			this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpStrength));
		}
		if (jump.GetComponent<Jump> ().getCanJump ()) {
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetAxis("Horizontal") != 0 && !jump.GetComponent<Jump> ().getCanJump () && !WallJump) {
			this.transform.Translate(new Vector2(horizontalStrength * Time.deltaTime * Input.GetAxis("Horizontal") * 0.8f, 0));	
		}
		if (Input.GetAxis("Horizontal") != 0 && jump.GetComponent<Jump> ().getCanJump ()) {
			this.transform.Translate(new Vector2(horizontalStrength * Time.deltaTime * Input.GetAxis("Horizontal"), 0));
		}
		if (Input.GetAxis("Horizontal") < 0) {
			this.transform.localScale = new Vector2(scale * -1, this.transform.localScale.y);
		} else if (Input.GetAxis("Horizontal") > 0) {
			this.transform.localScale = new Vector2(scale, this.transform.localScale.y);
		}

		if ( Input.GetAxis("Fire1") == 1 && attackCurrentDelay <= 0 )
		{
			Attack();
		}
	}

	IEnumerator timer_jump() {

		timerJump = true;
		yield return new WaitForSeconds (0.07f);
		timerJump = false;
	}

	protected virtual void Attack()
	{
		attackCurrentDelay = attackDelay;
		animator.SetTrigger( animAttack );
		audioSource.PlayOneShot( sounds[0] );
	}

	public void PlayerAttack( int _animID)
	{
		animID = _animID;
		animator.SetInteger( animID, animAttackID );
		animator.SetTrigger( animAttack );
		audioSource.PlayOneShot( sounds[animAttackID] );
	}

	public void Die()
	{
		animator.SetTrigger( animDeath );
		IsDead = true;
		audioSource.PlayOneShot( sounds[1] );
	}

	public void Lives()
	{
		animator.SetTrigger( "AnimEnd" );
		IsDead = true;
	}

	public bool IsDead {
		get;
		protected set;
	}

	public int playerID
	{
		get
		{
			return _playerID;
		}
		set
		{
			if ( value != 1 && value != 2 )
				_playerID = 1;
			else
				_playerID = value;
		}
	}
}