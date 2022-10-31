using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : RPGState
{
    public override void Enter()
    {
        Debug.Log("Player Loses");
    }

    public override void Exit()
    {

    }
}
