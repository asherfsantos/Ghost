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
	public Rigidbody2D playerLiveForm;
	public GameObject playerSpiritForm;
	public Vector2 currentPosition;
	public Animator anim;
	private bool attack;
	private Animator myAnimator;
	public bool isInRealWolrd = true;

	public GameObject[] realEnemies;

	public bool realWorldActive = true;

	public float realLeft = -0.5f;
	public float realRight = 5.0f;
	public float realUpper = 3.0f;
	public float realLower = -2.5f;
	
	void Start () 
	{
		player = GetComponent<Rigidbody2D>();
		playerRenderer = player.GetComponent<SpriteRenderer>();
		myAnimator = GetComponent<Animator>();
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

		HandleInput();
		
	}

	void Update () 
	{
		//tell the animator which animation to play
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
		anim.SetFloat ("Speed", Mathf.Abs (horizontal) + Mathf.Abs (vertical));

		//triggers attack
		HandleAttacks();
		ResetValues();
		//if(transform.position.x < -6.45 || transform.position.x > 6.05 || transform.position.y < -3.25 || transform.position.y > 3.75)
		if(!coordInRealWorld(transform.position.x, transform.position.y))
		{
			realEnemies = GameObject.FindGameObjectsWithTag("RealEnemy");
			foreach (GameObject enemy in realEnemies)
        	{
				GrimDevourerScript thisScript;
				thisScript = enemy.GetComponent<GrimDevourerScript>();
				thisScript.attackActive = false;
        	}
			realWorldActive = false;
		}
			//disable real world
			//enable ghost world
		else
		{
			//disable ghost world
			//enable real world
			realEnemies = GameObject.FindGameObjectsWithTag("RealEnemy");
			foreach (GameObject enemy in realEnemies)
        	{
				GrimDevourerScript thisScript;
				thisScript = enemy.GetComponent<GrimDevourerScript>();
				thisScript.attackActive = true;
        	}
			realWorldActive = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.CompareTag("Doorway"))
		{
			//isInRealWolrd = !isInRealWolrd;
			toggleGravity();
			GameObject thePlayer = GameObject.Find("Player");
			PlayerManager playerScript = thePlayer.GetComponent<PlayerManager>();
			
			while(playerScript.realWorldHealth < 3)
        		playerScript.realWorldHealth++;
			
			//GameObject.Destroy(player);
		}
	}

	void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	
	private void HandleAttacks()
	{
		if (attack)
		{
			myAnimator.SetTrigger("Attack");
		}
	}

	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			attack = true;
		}
	}

	private void ResetValues()
	{
		attack = false;
	}
	private bool coordInRealWorld(float x, float y)
	{
		if((x > realLeft && x < realRight) && (y > realLower && y < realUpper))
			return true;
		else
			return false;
	}
	
	private void toggleGravity()
	{
		GameObject thePlayer = GameObject.Find("Player");
		Rigidbody2D playerPhysics = thePlayer.GetComponent<Rigidbody2D>();
			if(isInRealWolrd)
				playerPhysics.gravityScale = 1;
			else
				playerPhysics.gravityScale = 0;
	}
}
