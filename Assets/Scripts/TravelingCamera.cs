using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingCamera : MonoBehaviour {

    public float speed = 5f;
    public Transform target;
    public Vector3 offset;
    private float start_speed = 0;
    private Vector3 cur;
    private float cur_f;
    private Vector3 last;
    private bool init = false;

    void Start()
    {
        start_speed = 4 * speed;
    }
	// Update is called once per frame
	void Update () {
		if (target == null)
			return;
        if (start_speed > speed)
            start_speed -= Time.deltaTime * 0.1f;
        
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref cur, start_speed);
        last = transform.position;
    }
}
