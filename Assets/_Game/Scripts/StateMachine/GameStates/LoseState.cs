using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _attackMenu;
    [SerializeField] GameObject _gameoverMenu;
    [SerializeField] MusicManager _music;
    [SerializeField] RoomProgression _roomProgression;

    public override void Enter()
    {
        Debug.Log("Player Loses");
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);
        _gameoverMenu.gameObject.SetActive(true);
        _music.DefeatMusic();
        _roomProgression.ResetRooms();
    }

    public override void Exit()
    {

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
