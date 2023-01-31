using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectWithHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    protected GameManager gameManager;

    protected void FindManager() // ABSTRACTION
    {        
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public virtual void getDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Dead();
            Destroy(gameObject);            
        }
    }

    public abstract void Dead(); // ABSTRACTION
}
