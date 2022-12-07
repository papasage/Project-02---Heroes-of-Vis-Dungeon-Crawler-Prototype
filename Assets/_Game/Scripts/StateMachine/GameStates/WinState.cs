using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _attackMenu;
    [SerializeField] GameObject _victoryMenu;
    [SerializeField] GameObject _bossVictoryMenu;
    [SerializeField] MusicManager _music;
    [SerializeField] GameObject _enemySprite;
    [SerializeField] RoomProgression _roomProgression;
    [SerializeField] int roomGoal;
    [SerializeField] PlayerHealth _playerHealth;

    public override void Enter() 
    {
        Debug.Log("Player Wins!");
        _enemySprite.SetActive(false);
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);

        if (_roomProgression.roomCount % 5 == 0)
        {
            _bossVictoryMenu.gameObject.SetActive(true);
        }
        else _victoryMenu.gameObject.SetActive(true);
        
        _music.VictoryMusic();

        roomGoal = PlayerPrefs.GetInt("RoomGoal");

        PlayerPrefs.SetInt("PlayerHealth", _playerHealth.playerHealth);
        PlayerPrefs.Save();
    }

    public override void Exit() 
    {
        //_attackMenu.SetActive(true);
        //_playerTurnTextUI.gameObject.SetActive(true);
        //_victoryMenu.gameObject.SetActive(false);
    }

    public void Continue()
    {
        //reload current scene (NEEDS A BETTER SOLUTION FOR ADDING TO ROOM COUNT)
        if (_roomProgression.roomCount == roomGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
