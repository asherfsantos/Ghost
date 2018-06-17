using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour 
{

	public GameObject portal;
	public GameObject spawnedPortal;
	public GameObject enemy;
	//public GameObject spawnedEnemy;
	float randomX;
	float randomY;
	Vector2 spawnLocation;
	Vector2 prevSpawnLocation;
	public float spawnRate = 3.0f;
	public float nextSpawn = 0.0f;
	public float minSpaceBetween = 2.0f;
	public bool spawnActive = true;
	

	void Start () 
	{
		
	}
	
	void Update () 
	{
		SpawnEnemies();
	}
	
	void SpawnEnemies()
	{
		GameObject thePlayer = GameObject.Find("Player");
		PlayerMovements playerScript = thePlayer.GetComponent<PlayerMovements>();
		spawnActive = playerScript.realWorldActive;

		if(spawnActive == true)
		{
			thePlayer = GameObject.FindWithTag("Player");
			PlayerMovements playerMoves = thePlayer.GetComponent<PlayerMovements>();
				if(playerMoves.realWorldActive == true)
				{
					if(Time.time > nextSpawn)
					{
						nextSpawn = Time.time + spawnRate;
						randomX = Random.Range(-0.5f, 5.0f);
						randomY = Random.Range(-2.5f, 3.0f);
						while ( (Mathf.Abs (prevSpawnLocation.x - randomX) < minSpaceBetween) || (Mathf.Abs (prevSpawnLocation.y - randomY)) < minSpaceBetween)
						{
							randomX = Random.Range(-5.5f, 5.0f);
							randomY = Random.Range(-2.5f, 3.0f);
						}
						spawnLocation = new Vector2(randomX, randomY);
						spawnedPortal = Instantiate(portal, spawnLocation, Quaternion.identity);
						Instantiate(enemy, spawnLocation, Quaternion.identity);
						prevSpawnLocation = spawnLocation;
						Destroy(spawnedPortal, 1.0f);
					}
				}
		}
	}
}
