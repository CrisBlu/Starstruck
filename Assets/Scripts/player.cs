using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
		if ( Input.GetKeyDown(KeyCode.Space))
		{
			//GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse)
		}
	}
}
