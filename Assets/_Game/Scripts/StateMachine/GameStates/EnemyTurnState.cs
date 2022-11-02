using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyTurnState : RPGState
{
    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] Text _enemyAttackAnimation = null;
    [SerializeField] Text _enemyThinkingText = null;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        //ENEMY THINKING START
        _enemyThinkingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(pauseDuration);
        _enemyThinkingText.gameObject.SetActive(false);
        //ENEMY THINKING END
        
        //ATTACK ANIMATION START
        _enemyAttackAnimation.gameObject.SetActive(true);
        yield return new WaitForSeconds(pauseDuration);
        _enemyAttackAnimation.gameObject.SetActive(false);
        //ATTACK ANIMATION END

        //turn over. Go back to Player
        StateMachine.ChangeState<PlayerTurnState>();
    }
}
