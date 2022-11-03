using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyTurnState : RPGState
{
    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] Text _enemyAttackAnimation = null;
    [SerializeField] Text _enemyLog = null;
    [SerializeField] Enemy _enemy;
    [SerializeField] PlayerHealth _playerHealth;


    public override void Enter()
    {
        
        Debug.Log("Enemy Turn: START");
        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));

        
    }


    public override void Exit()
    {
        Debug.Log("Enemy Turn: END");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        //ENEMY THINKING START
        _enemyLog.gameObject.SetActive(true);
        _enemyLog.text = "...enemy thinking...";

        //this is where the enemy will choose attack 1 or 2
        int _rand = UnityEngine.Random.Range(0, 2);
        Debug.Log(_rand);

       yield return new WaitForSeconds(pauseDuration);
        _enemyLog.gameObject.SetActive(false);
        //ENEMY THINKING END
        
        //ATTACK ANIMATION START
        _enemyAttackAnimation.gameObject.SetActive(true);

        //ENEMY ATTACK
        switch (_rand)
        {
            case 0: 
                _enemy.Attack1();
                break;
            case 1:
                _enemy.Attack2();
                break;

            default: break;
        }


        yield return new WaitForSeconds(pauseDuration);
        _enemyAttackAnimation.gameObject.SetActive(false);
        //ATTACK ANIMATION END

        if (_playerHealth.playerHealth > 0)
        {
            //player alive, next turn
            StateMachine.ChangeState<PlayerTurnState>();
        }

        //player dead. game over
        else StateMachine.ChangeState<LoseState>();
    }
}
