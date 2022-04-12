using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Behavior : MonoBehaviour {

	public GameObject PlayerViewport;
	public GameObject EnemyBullet;
	
	// Use this for initialization
	void Start () {
		transform.LookAt(PlayerViewport.transform);
		Shoot();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * 5f * Time.deltaTime;
	}

	private IEnumerator Shoot()
	{
		while (true)
		{
			//Instantiate(EnemyBullet, 
			yield return new WaitForSeconds(5);
		}
	}
}
