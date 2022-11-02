using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _attackMenu;

    public override void Enter() 
    {
        Debug.Log("Player Wins!");
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);
    }

    public override void Exit() 
    {
    
    }
}
