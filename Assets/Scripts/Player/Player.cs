using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Player : ObjectWithHealth
{
    private void Start()
    {
        FindManager();
    }

    public override void Dead() // POLYMORPHISM
    {
        gameManager.IsGameOVer = true;
    }
}
