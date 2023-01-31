using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ObjectWithHealth
{
    private void Start()
    {
        FindManager();
    }

    public override void Dead()
    {
        gameManager.IsGameOVer = true;
    }
}
