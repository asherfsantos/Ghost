using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour 
{

	public GameObject portal;
	public GameObject spawnedPortal;
	public GameObject enemy;
	public GameObject spiritEnemy;
	float randomX;
	float randomY;
	Vector2 spawnLocation;
	Vector2 prevSpawnLocation;
	public float spawnRate = 3.0f;
	public float nextSpawn = 0.0f;
	public float minSpaceBetween = 2.0f;
	public bool realSpawnActive = true;

	private float realLeft = -0.5f;
	private float realRight = 5.0f;
	private float realUpper = 3.0f;
	private float realLower = -2.5f;
	

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
		realSpawnActive = playerScript.realWorldActive;
		thePlayer = GameObject.FindWithTag("Player");
		PlayerMovements playerMoves = thePlayer.GetComponent<PlayerMovements>();

		if(realSpawnActive == true)
		{
			if(Time.time > nextSpawn)
			{
				nextSpawn = Time.time + spawnRate;
				randomX = Random.Range(realLeft, realRight);
				randomY = Random.Range(realLower, realUpper);
				while ( (Mathf.Abs (prevSpawnLocation.x - randomX) < minSpaceBetween) || (Mathf.Abs (prevSpawnLocation.y - randomY)) < minSpaceBetween)
				{
					randomX = Random.Range(realLeft, realRight);
					randomY = Random.Range(realLower, realUpper);
				}
				spawnLocation = new Vector2(randomX, randomY);
				spawnedPortal = Instantiate(portal, spawnLocation, Quaternion.identity);
				Instantiate(enemy, spawnLocation, Quaternion.identity);
				prevSpawnLocation = spawnLocation;
				Destroy(spawnedPortal, 1.0f);
			}
		}
		else
		{
			if(Time.time > nextSpawn)
			{
				float leftRandX, rightRandX, lowerRandY, upperRandY;
				nextSpawn = Time.time + spawnRate;
				leftRandX = Random.Range(-9.5f, -0.5f);
				rightRandX = Random.Range(5.8f, 9.5f);
				lowerRandY = Random.Range(-3.25f, -5.3f);
				upperRandY = Random.Range(3.75f, 5.3f);
				randomX = chooseBetween(leftRandX, rightRandX);
				randomY = chooseBetween(lowerRandY, upperRandY);
				while ( (Mathf.Abs (prevSpawnLocation.x - randomX) < minSpaceBetween) || (Mathf.Abs (prevSpawnLocation.y - randomY)) < minSpaceBetween )
				{
					leftRandX = Random.Range(-9.5f, -0.5f);
					rightRandX = Random.Range(5.8f, 9.5f);
					lowerRandY = Random.Range(-3.25f, -5.3f);
					upperRandY = Random.Range(3.75f, 5.3f);
					randomX = chooseBetween(leftRandX, rightRandX);
					randomY = chooseBetween(lowerRandY, upperRandY);
				}
				spawnLocation = new Vector2(randomX, randomY);
				spawnedPortal = Instantiate(portal, spawnLocation, Quaternion.identity);
				Instantiate(spiritEnemy, spawnLocation, Quaternion.identity);
				prevSpawnLocation = spawnLocation;
				Destroy(spawnedPortal, 1.0f);
			}
		}
	}
	private bool coordInRealWorld(float x, float y)
	{
		if((x > realLeft && x < realRight) && (y > realLower && y < realUpper))
			return true;
		else
			return false;
	}
	private float chooseBetween(float x1, float x2)
	{
		if(Random.value < 0.5f)
			return x1;
		else
			return x2;
	}
}
