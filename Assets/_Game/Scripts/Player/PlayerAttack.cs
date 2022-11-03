using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is where the player attacks are held.
//they are public so that they can be called from the button inputs on PlayerTurnState
//it connects to Enemy.cs so that it can deal direct damage


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] Text _playerLog;


    public void Fire(string _attackName)
    {
        _playerLog.text = "Flint used: " + _attackName;
        _enemy.TakeDamage(10);
    }
    public void Earth(string _attackName)
    {
        _playerLog.text = "Flint used: " + _attackName;
        _enemy.TakeDamage(20);
    } 
    public void Water(string _attackName)
    {
        _playerLog.text = "Flint used: " + _attackName;
        _enemy.TakeDamage(30);
    } 
    public void Wind(string _attackName)
    {
        _playerLog.text = "Flint used: " + _attackName;
        _enemy.TakeDamage(400);
    }
}
