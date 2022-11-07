using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseState : RPGState
{
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _attackMenu;
    [SerializeField] GameObject _gameoverMenu;
    [SerializeField] MusicManager _music;
    [SerializeField] RoomProgression _roomProgression;
    [SerializeField] TextMeshProUGUI _livedToSee;
    [SerializeField] TextMeshProUGUI _killedBy;
    [SerializeField] Enemy _enemy;

    public override void Enter()
    {
        Debug.Log("Player Loses");
        _attackMenu.SetActive(false);
        _playerTurnTextUI.gameObject.SetActive(false);
        _gameoverMenu.gameObject.SetActive(true);

        _killedBy.text = "You were felled by a \n" +  _enemy.enemyName;
        _livedToSee.text = "You lived to see Room " + _roomProgression.roomCount;

        _music.DefeatMusic();
        _roomProgression.ResetRooms();

        PlayerPrefs.SetInt("PlayerHealth", 0);
        PlayerPrefs.Save();
    }

    public override void Exit()
    {

    }

    public void ReturnToMainMenu()
    {
        PlayerPrefs.SetInt("PlayerHealth", 0);
        PlayerPrefs.Save();
        _roomProgression.ResetRooms();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
