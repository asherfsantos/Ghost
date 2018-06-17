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
	}

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.CompareTag("Doorway"))
		{
			isInRealWolrd = !isInRealWolrd;
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

}
