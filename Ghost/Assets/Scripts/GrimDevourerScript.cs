﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimDevourerScript : EnemyBase {

    #region Public Variables
    public float shootIntervalTime = 3f;
    public GameObject projectile;
    public Animator anim;
    public bool attackActive = true;
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    #endregion 

    #region Private Variables
    private float timer;
    private Transform myTransform;
    #endregion

    #region Monobehavior Callbacks
    // Use this for initialization
    void Start()
    {
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;

        Vector3 dir = target.position - myTransform.position;
         
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
            PlayerManager.instance.PlayerDeath();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }

    protected override void Movement()
    {
        //Grim Devourer does not move
    }

    #endregion
}
