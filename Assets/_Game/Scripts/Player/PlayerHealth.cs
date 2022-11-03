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


    private void Start()
    {
        _healthText.color = Color.white;
        playerHealth = _maxHealth;
    }

    public void TakeDamage(int _amount)
    {
        playerHealth -= _amount;
    }

    public void HealDamage(int _amount)
    {
        playerHealth += _amount;
    }

    private void Update()
    {
        _healthText.text = "Health: " + playerHealth.ToString();

        if (playerHealth <= 0)
        {
            _healthText.color = Color.red;
            _healthText.text = "DECEASED";
            _playerLog.gameObject.SetActive(true);
            _playerLog.text = "Flint has died!";
        }
    }
}
