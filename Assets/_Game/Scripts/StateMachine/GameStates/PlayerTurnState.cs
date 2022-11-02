using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] Text _playerAttackAnimation = null;
    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] GameObject _attackMenu;

    int _playerTurnCount = 0;

    public override void Enter()
    {
        //SHOW PLAYER TURN TEXT
        _playerTurnTextUI.gameObject.SetActive(true);
        _attackMenu.SetActive(true);

        //Increase turn count & print
        _playerTurnCount++;
        _playerTurnTextUI.text = "Player Turn: " + _playerTurnCount.ToString();

        //hook into events
        StateMachine.Input.PressedConfirm += OnPressedAttackOne;
        StateMachine.Input.PressedConfirm += OnPressedAttackTwo;
        StateMachine.Input.PressedConfirm += OnPressedAttackThree;
        StateMachine.Input.PressedConfirm += OnPressedAttackFour;
    }

    public override void Exit()
    {
        //disable player turn text
        _playerTurnTextUI.gameObject.SetActive(false);

        //unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedAttackOne;
        StateMachine.Input.PressedConfirm -= OnPressedAttackTwo;
        StateMachine.Input.PressedConfirm -= OnPressedAttackThree;
        StateMachine.Input.PressedConfirm -= OnPressedAttackFour;
        
        Debug.Log("Player Turn: Exiting...");
    }

    public void OnPressedAttackOne()
    {
        //Player uses first attack
        Debug.Log("Player Used Attack 1 ");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
    }

    public void OnPressedAttackTwo()
    {
        //Player uses second attack
        Debug.Log("Player Used Attack 2 ");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
    }

    public void OnPressedAttackThree()
    {
        //Player uses third attack
        Debug.Log("Player Used Attack 3 ");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
    }

    public void OnPressedAttackFour()
    {
        //Player uses fourth attack
        Debug.Log("Player Used Attack 4 ");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
        
    }

    public void PlayerWins()
    {
        //temp method for winstate button
        StateMachine.ChangeState<WinState>();  
    }

    public void PlayerLoses()
    {
        //temp method for losestate button
        StateMachine.ChangeState<LoseState>();
    }

    IEnumerator PlayerAttackAnimation(float pauseDuration)
    {
        _attackMenu.SetActive(false);

        Debug.Log("player attack animation plays HERE");

        //ATTACK ANIMATION START
        _playerAttackAnimation.gameObject.SetActive(true);
        yield return new WaitForSeconds(pauseDuration);
        _playerAttackAnimation.gameObject.SetActive(false);
        //ATTACK ANIMATION END

        StateMachine.ChangeState<EnemyTurnState>();
    }
}
