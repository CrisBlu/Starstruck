using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour {

	public float speed;
	public AudioClip explosionSound;

	// Use this for initialization
	void Start()
	{
		Invoke("Explode", 100f);
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += transform.forward * 10f * Time.deltaTime * speed;
	}


	void OnTriggerEnter(Collider other)
	{
		//Die when something touches you
		if (other.gameObject.layer == 8)
		{
			Destroy(other.gameObject);
		}
		Explode();
	}

	void Explode()
	{
		GameObject.Find("ParticleCreator").GetComponent<ParticleCreator>().PlayExplosionAt(transform.position);
		AudioSource.PlayClipAtPoint(explosionSound, transform.position);
		Destroy(gameObject);
	}
}
