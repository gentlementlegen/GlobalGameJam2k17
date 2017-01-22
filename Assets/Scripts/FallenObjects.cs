using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObjects : MonoBehaviour {

    public float delay = 0.2f;
    private Rigidbody2D _rb;
	private Vector3 originPos;
	private Quaternion originRot;
	private bool freeze = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb)
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
			_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
		originPos = transform.position;
		originRot = transform.rotation;
    }
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.transform.CompareTag("Player"))
        {
			_rb.constraints = RigidbodyConstraints2D.None;
        }
    }

	public void ReStart()
	{
		if (!freeze) {
			_rb.constraints = RigidbodyConstraints2D.FreezeAll;
			transform.position = originPos;
			transform.rotation = originRot;
		}
	}

	public void Freeze()
	{
		freeze = true;
	}
}
