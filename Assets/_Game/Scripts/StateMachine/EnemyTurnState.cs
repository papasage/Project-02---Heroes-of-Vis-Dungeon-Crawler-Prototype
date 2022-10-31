using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnState : RPGState
{
    public static event Action EnemyTurnBegan; 
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        //StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }
}
