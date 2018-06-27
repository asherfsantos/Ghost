using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	private void OnCollisionEnter(Collision other)
	{
		/*if (other.gameObject.tag == "RealEnemy")
		{
			Destroy(other.gameObject);
			print("Attack");
		}*/
		print("Attack");
	}
	
}
