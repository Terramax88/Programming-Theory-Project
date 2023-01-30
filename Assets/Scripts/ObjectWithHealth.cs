using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithHealth : MonoBehaviour
{
    public int health = 10;
    public bool is_Dead = false;

    public virtual void getDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            is_Dead = true;
        }
    }
}
