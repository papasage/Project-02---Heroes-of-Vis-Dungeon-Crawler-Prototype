using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : RPGState
{
    public override void Enter() 
    {
        Debug.Log("Player Wins!");
    }

    public override void Exit() 
    {
    
    }
}
