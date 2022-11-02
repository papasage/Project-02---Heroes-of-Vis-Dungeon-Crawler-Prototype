using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    public int playerHealth;

    private void Start()
    {
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
}
