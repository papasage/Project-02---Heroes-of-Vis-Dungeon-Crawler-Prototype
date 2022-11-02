using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _attackMenu;
    [SerializeField] GameObject _victoryMenu;

    public override void Enter() 
    {
        Debug.Log("Player Wins!");
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);
        _victoryMenu.gameObject.SetActive(true);
    }

    public override void Exit() 
    {
        _attackMenu.SetActive(true);
        _playerTurnTextUI.gameObject.SetActive(true);
        _victoryMenu.gameObject.SetActive(false);
    }

    public void Continue()
    {

    }
}
