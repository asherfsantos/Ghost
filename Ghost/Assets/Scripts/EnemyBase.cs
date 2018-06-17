using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {
    public int health = 1;
    public int movementSpeed = 1;
    protected abstract void Movement();
}
