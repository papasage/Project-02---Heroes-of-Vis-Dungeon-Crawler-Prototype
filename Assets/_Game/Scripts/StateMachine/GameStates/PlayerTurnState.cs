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
    [SerializeField] Text _playerLog;
    [SerializeField] PlayerAttack _playerattack;
    [SerializeField] Enemy _enemy;

    int _playerTurnCount = 0;
    bool _playerAttackOver = false;

    public override void Enter()
    {
        _playerAttackOver = false;
        Debug.Log("Player Turn: START");

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

    private void Update()
    {
        if (_playerAttackOver == true)
        {

            //turn over


            if (_enemy.enemyHealth > 0)
            {
                //enemy alive, next turn
                _playerAttackOver = false;
                StateMachine.ChangeState<EnemyTurnState>();
            }

            //enemy dead. victory!
            else StateMachine.ChangeState<WinState>();


        }
    }

    public override void Exit()
    {
        //unhook from events
        StateMachine.Input.PressedConfirm -= OnPressedAttackOne;
        StateMachine.Input.PressedConfirm -= OnPressedAttackTwo;
        StateMachine.Input.PressedConfirm -= OnPressedAttackThree;
        StateMachine.Input.PressedConfirm -= OnPressedAttackFour;
        
        Debug.Log("Player Turn: END");
    }

    public void OnPressedAttackOne()
    {
        //Player uses first attack
        _playerattack.Fire("FLARE");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
    }

    public void OnPressedAttackTwo()
    {
        //Player uses second attack
        _playerattack.Earth("BREAKER");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
    }

    public void OnPressedAttackThree()
    {
        //Player uses third attack
        _playerattack.Water("DROWN");
        StartCoroutine(PlayerAttackAnimation(_pauseDuration));
    }

    public void OnPressedAttackFour()
    {
        //Player uses fourth attack
        _playerattack.Wind("VACUUM");
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
        Debug.Log("Player Menus Disabled");
        //disable player turn text
        _playerTurnTextUI.gameObject.SetActive(false);
        _attackMenu.SetActive(false);

        //ATTACK ANIMATION START
        _playerAttackAnimation.gameObject.SetActive(true);
        _playerLog.gameObject.SetActive(true);
        yield return new WaitForSeconds(pauseDuration);
        _playerAttackAnimation.gameObject.SetActive(false);
        _playerLog.gameObject.SetActive(false);
        //ATTACK ANIMATION END

        _playerAttackOver = true;
        
    }

    //here is how i want the player attacks to work:
    //the coroutine currently being called will be played for all attacks to control pacing and animation
    //but attacks 1-4 will  ALSO call public variables from a seperate attack script that has methods for unique attacks. 
    //this player attack script will work similarly to my MusicManager in that it will just be a list of public methods 
    //if i want the player attacks to be able to be swapped out, I will need to have this attack script start with 4 main methods that trickle down to more specific attack methods
    //i am not sure how to do this last part. i guess all of the possible attacks will be on that script and the 4 main attack slots will need to check what they have access to?
}
