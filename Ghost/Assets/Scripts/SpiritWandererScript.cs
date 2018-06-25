using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritWandererScript : EnemyBase {

    #region Public Variables
    public float xDir, yDir;
    public bool isChasing;
    public int damage = 1;
    #endregion

    #region Private Variables
    private GameObject player;
    #endregion

    #region Monobehavior Callbacks
    // Use this for initialization
    void Start () {
        isChasing = false;
        xDir = UnityEngine.Random.Range(-1f, 1f);
        yDir = UnityEngine.Random.Range(-1f, 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    protected override void Movement()
    {
        if(isChasing)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, PlayerManager.instance.transform.position, step);
        }
        else 
            transform.Translate(new Vector3(xDir, yDir, 0)*Time.deltaTime*movementSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerManager.instance.TakeSpiritWorldDamage(damage);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        xDir = UnityEngine.Random.Range(-1f, 1f);
        yDir = UnityEngine.Random.Range(-1f, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            isChasing = true;
        else
        {
            xDir = UnityEngine.Random.Range(-1f, 1f);
            yDir = UnityEngine.Random.Range(-1f, 1f);
        }     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isChasing = false;
    }
    #endregion
}
