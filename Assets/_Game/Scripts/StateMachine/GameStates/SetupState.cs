using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupState : RPGState
{
    [SerializeField] int _startingCardNumber = 10;
    [SerializeField] int _numberOfPlayers = 2;

    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Creating " + _numberOfPlayers + " players.");
        Debug.Log("Creating deck with " + _startingCardNumber + " cards.");
        //CANT change state while still in Enter()/Exit() transition
        //Dont put ChangeState<> here.
        _activated = false;
    }

    public override void Tick()
    {
       //you would usually have delays or input here

        if(_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnState>();
        }
    }

    public override void Exit()
    {
        Debug.Log("Setup: Exiting...");
    }
}
