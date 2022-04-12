using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

	public float speed;
	public AudioClip blastSound;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 20f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * 10f * Time.deltaTime * speed;
	}


	void OnTriggerEnter(Collider other)
	{
		//Die when something touches you
		if (other.gameObject.layer == 8) Destroy(other.gameObject);
		GameObject.Find("ParticleCreator").GetComponent<ParticleCreator>().PlayEnergyBlastAt(transform.position);
		AudioSource.PlayClipAtPoint(blastSound, transform.position);
		Destroy(gameObject);
	}
}
