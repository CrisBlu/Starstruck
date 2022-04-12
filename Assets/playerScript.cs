using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour {

	public GameObject Bullet;
	public GameObject Rocket;
	public GameObject Gun;
	public AudioSource bulletSound;
	public AudioSource rocketSound;
	private PlayerInputs m_playerInputs;
	public float fireRate = .5F;
	public float nextFire = 0.0F;

	public float bulletCooldownTime = 1f;
	public float lastBulletFiredTime = 0;

	public float rocketCooldownTime = 3f;
	public float lastRocketFiredTime = 0;

	public int hp = 2;
	void Start()
	{
		//m_playerInputs = GetComponent<PlayerInputs>();
		Debug.Log(getReal3D.Input.buttonsName());

	}
	

	// Update is called once per frame
	void Update () {

		if ((getReal3D.Input.GetButtonDown("ShootBullet") || getReal3D.Input.buttons[1] == 1) && Time.time - lastBulletFiredTime > bulletCooldownTime)
		{
			bulletSound.Play();
			Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation * Quaternion.Euler(90, 0, 0));
			lastBulletFiredTime = Time.time;
		}
		if ((getReal3D.Input.GetButtonDown("ShootRocket") || getReal3D.Input.buttons[2] == 1) && Time.time - lastRocketFiredTime > rocketCooldownTime)
		{
			rocketSound.Play();
			Instantiate(Rocket, Gun.transform.position, Gun.transform.rotation * Quaternion.Euler(90, 0, 0));
			lastRocketFiredTime = Time.time;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		//Die when something touches you
		//Added a buffer because of the bullshit ship that spawns
		//at the beginning that doesn't always spawn in view
		hp -= 1;
		Debug.Log("Health: " + hp);
		if (hp == 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

}
