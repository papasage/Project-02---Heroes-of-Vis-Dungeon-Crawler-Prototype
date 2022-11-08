using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    public int playerHealth;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] Text _playerLog;
    [SerializeField] int roomCount;
    [SerializeField] PlayerAttack _playerAttack;

    private void Start()
    {
        _healthText.color = Color.white;
        

        roomCount = PlayerPrefs.GetInt("RoomCount");

        if (roomCount <= 1)
        {
            playerHealth = _maxHealth;
        }

        else playerHealth = PlayerPrefs.GetInt("PlayerHealth",_maxHealth);


    }

    public void TakeDamage(int _amount)
    {
        playerHealth -= _amount;

        //Save the Player's Health
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.Save();
    }

    public void HealDamage(int _amount)
    {

        playerHealth += _amount;

        //Save the Player's Health
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        _healthText.text = "Health: " + playerHealth.ToString();

        if (playerHealth <= 0)
        {
            _healthText.color = Color.red;
            _healthText.text = "DECEASED";
            _playerLog.gameObject.SetActive(true);
            _playerAttack._playerLogSymbol.sprite = _playerAttack._deathSymbol;
            _playerLog.text = "Flint has died!";
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PlayerHealth", 0);
        PlayerPrefs.Save();
    }
}
