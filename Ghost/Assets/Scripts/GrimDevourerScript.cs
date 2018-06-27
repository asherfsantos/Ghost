using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimDevourerScript : EnemyBase {

    #region Public Variables
    public float shootIntervalTime = 3f;
    public GameObject projectile;
    public Animator anim;
    public bool attackActive = true;
    public float xDir, yDir;
    public bool isChasing;
    public int damage = 1;
    #endregion 

    #region Private Variables
    private float timer;

    #endregion

    #region Monobehavior Callbacks
    // Use this for initialization
    void Start()
    {
        timer = 0;
        isChasing = false;
        xDir = UnityEngine.Random.Range(-1f, 1f);
        yDir = UnityEngine.Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Movement();
    }

    private void Shoot()
    {
        if(attackActive == true)
        {
            timer += Time.deltaTime;
            if(timer > shootIntervalTime)
            {
                timer = 0;
                SpawnProjectile();
            }
        }
    }
    private void SpawnProjectile()
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.GetComponent<Projectile>().SetMoving();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerManager.instance.TakeSpiritWorldDamage(damage);
        if(collision.gameObject.tag == "Attack")
            print("Attacked");

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

    #endregion
}
