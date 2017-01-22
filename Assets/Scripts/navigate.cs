using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
	}
}
