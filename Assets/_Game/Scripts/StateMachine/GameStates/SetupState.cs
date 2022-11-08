using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupState : RPGState
{
    [SerializeField] int _startingCardNumber = 10;
    [SerializeField] int _numberOfPlayers = 2;
    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] GameObject _setupWindow;
    [SerializeField] SFXManager _sfx;
    [SerializeField] Enemy _enemy;
    [SerializeField] GameObject _enemySprite;
    [SerializeField] EnemyGenerator _enemyGenerator;
    [SerializeField] RoomProgression _roomProgression;
    [SerializeField] TextMeshProUGUI _roomSetupCount;
    [SerializeField] TextMeshProUGUI _roomCounter;

    bool _activated = true;

    public override void Enter()
    {
        Debug.Log("Setup: ...Entering");
        Debug.Log("Room Goal " + PlayerPrefs.GetInt("RoomGoal"));
        _roomProgression.NewRoom();

        _enemySprite.SetActive(false);
        StartCoroutine(EnemyAppearsMessage(_pauseDuration));

        _enemyGenerator.GenerateEnemy();

        _roomCounter.text = _roomProgression.roomCount.ToString();
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
        _roomSetupCount.text = "ROOM " + _roomProgression.roomCount.ToString();
        //_sfx.MonsterCrySFX();

        yield return new WaitForSeconds(pauseDuration);
        _setupWindow.SetActive(false);
        //Setup message off
        _enemySprite.SetActive(true);
        _enemy.StartCoroutine(_enemy.IdleDance(_enemy._idleDanceTime, _enemy.portrait, _enemy.portrait2));

        StateMachine.ChangeState<PlayerTurnState>();
    }

}
