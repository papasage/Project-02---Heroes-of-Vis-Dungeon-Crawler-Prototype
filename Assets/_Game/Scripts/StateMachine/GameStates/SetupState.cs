using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupState : RPGState
{
    [SerializeField] int _startingCardNumber = 10;
    [SerializeField] int _numberOfPlayers = 2;
    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] GameObject _setupWindow;
    [SerializeField] SFXManager _sfx;

    bool _activated = true;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Creating " + _numberOfPlayers + " players.");
        Debug.Log("Creating deck with " + _startingCardNumber + " cards.");
        //CANT change state while still in Enter()/Exit() transition

        StartCoroutine(EnemyAppearsMessage(_pauseDuration));

        //Dont put ChangeState<> here.
        
    }

    public override void Tick()
    {
       //you would usually have delays or input here

        if(_activated == false)
        {
            _activated = true;
            
        }
    }

    public override void Exit()
    {
        Debug.Log("Setup: Exiting...");
    }

    IEnumerator EnemyAppearsMessage(float pauseDuration)
    {
        //Setup message on
        _setupWindow.SetActive(true);

        //_sfx.MonsterCrySFX();

        yield return new WaitForSeconds(pauseDuration);
        _setupWindow.SetActive(false);
        //Setup message off
        StateMachine.ChangeState<PlayerTurnState>();
    }
}
