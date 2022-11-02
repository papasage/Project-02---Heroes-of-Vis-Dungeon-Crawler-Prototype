using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _attackMenu;

    public override void Enter()
    {
        Debug.Log("Player Loses");
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);
    }

    public override void Exit()
    {

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
