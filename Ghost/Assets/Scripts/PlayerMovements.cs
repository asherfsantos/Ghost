using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour 
{
	private Rigidbody2D player;
	public float speed;
	public bool playerInPortal;
	public Sprite spiritSprite;
	public SpriteRenderer playerRenderer;
	public bool isLiving = true;
	public bool facingRight = true;
	

	void Start () 
	{
		player = GetComponent<Rigidbody2D>();
		playerRenderer = player.GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		transform.Translate(new Vector3(moveHorizontal, moveVertical) * Time.deltaTime * speed);
		if(moveHorizontal > 0 && !facingRight)
           	Flip();
        else if(moveHorizontal < 0 && facingRight)
           	Flip();
	}

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Portal"))
		{
			isLiving = !isLiving;
			if(isLiving)
			{
				//living animation
			}
			else if(!isLiving)
			{
				//spirit animation
			}
		}
	}

	void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
