using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemyDamage;
    [SerializeField] PlayerHealth _player;


    public void Attack()
    {
        _player.TakeDamage(enemyDamage);
    }
}
