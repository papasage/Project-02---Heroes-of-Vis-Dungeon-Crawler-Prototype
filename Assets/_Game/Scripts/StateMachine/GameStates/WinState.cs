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
    [SerializeField] MusicManager _music;
    [SerializeField] GameObject _enemySprite;
    [SerializeField] RoomProgression _roomProgression;
    [SerializeField] PlayerHealth _playerHealth;

    public override void Enter() 
    {
        Debug.Log("Player Wins!");
        _enemySprite.SetActive(false);
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);
        _victoryMenu.gameObject.SetActive(true);
        _music.VictoryMusic();

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
