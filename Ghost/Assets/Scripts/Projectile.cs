using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    #region Public Variables
    public float speed = 50f;
    public int damage = 1;
    #endregion

    #region Private Variables
    private bool isMoving;
    private Vector3 normalizedPosition;
    #endregion

    #region Monobehavior Callbacks
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
            return;
        float step = speed * Time.deltaTime;

        transform.position += normalizedPosition * speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Public Functions
    public void SetMoving()
    {
        isMoving = true;
        normalizedPosition = (PlayerManager.instance.transform.position - transform.position).normalized;
    }
    #endregion

}
