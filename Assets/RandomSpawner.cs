using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : getReal3D.MonoBehaviourWithRpc {

	public GameObject[] enemyPrefab;
	public Material[] enemyColors;
	public float wait = 3;
	public int posX;
	public int posZ;

	public int num = 20;

	// Update is called once per frame
	void Start () {
		StartCoroutine(ExampleCoroutine());

	}

	public IEnumerator ExampleCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(wait);
			CallRpc("DetermineSpawnLocation", Random.Range(0, 11));
			CallRpc("RandomSpawnPosition", Random.Range(0, enemyPrefab.Length - 1), Random.Range(0, enemyColors.Length - 1), Random.Range(posX - num, posX + num), Random.Range(-30, 30), Random.Range(posZ - num, posZ + num));
			
			if (wait > 0.75f)
			{
				wait -= .15f;
			}
			Debug.Log(wait);
		}
	}
	[getReal3D.RPC]
	void DetermineSpawnLocation(int pos)
	{
		//"Circle" like spawning
		//Randomly determine staring position, then from there add a bit of variation and spawn the enmemy
		Debug.Log("SHIP SPAWN: " + pos);
		switch (pos)
		{
			case 0:
				posX = 0;
				posZ = 100;
				break;
			case 1:
				posX = -40;
				posZ = 90;
				break;
			case 2:
				posX = -60;
				posZ = 80;
				break;
			case 3:
				posX = -85;
				posZ = 50;
				break;
			case 4:
				posX = -90;
				posZ = 40;
				break;
			case 5:
				posX = -100;
				posZ = 0;
				break;
			case 6:
				posX = 40;
				posZ = 90;
				break;
			case 7:
				posX = 60;
				posZ = 80;
				break;
			case 8:
				posX = 85;
				posZ = 50;
				break;
			case 9:
				posX = 90;
				posZ = 40;
				break;
			case 10:
				posX = 100;
				posZ = 0;
				break;

		}
	}
	
	[getReal3D.RPC]
	void RandomSpawnPosition(int enemy, int colorIndex, int x, int y, int z)
	{
		Vector3 Position = new Vector3(x, y, z);
		GameObject spawnedEnemy = Instantiate(enemyPrefab[enemy], Position, Quaternion.identity);
		spawnedEnemy.GetComponent<Renderer>().material = enemyColors[colorIndex];
	}
}
