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
    [SerializeField] SFXManager _sfx;


    public void Fire(string _attackName, int _dmgAmount)
    {
        //fire attacks crit on eath elementals
        _sfx.FireSFX();

        if (_enemy.earthType == true)
        {
            _enemy.TakeDamage(_dmgAmount * 2);
            _playerLog.color = Color.green;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's effective!";
        }
        else if (_enemy.fireType == true)
        {
            _enemy.TakeDamage(_dmgAmount / 2);
            _playerLog.color = Color.red;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's suboptimal...";
        }
        else if (_enemy.windType == true)
        {
            _enemy.TakeDamage(_dmgAmount / 2);
            _playerLog.color = Color.red;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's suboptimal...";
        }
        else
        {
            _enemy.TakeDamage(_dmgAmount);
            _playerLog.color = Color.white;
            _playerLog.text = "Flint used: " + _attackName;
        }
    }
    public void Earth(string _attackName, int _dmgAmount)
    {
        //earth attacks crit on water elementals
        _sfx.EarthSFX();

        if (_enemy.waterType == true)
        {
            _enemy.TakeDamage(_dmgAmount * 2);
            _playerLog.color = Color.green;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's effective!";
        }
        else if (_enemy.earthType == true) 
        {
            _enemy.TakeDamage(_dmgAmount / 2);
            _playerLog.color = Color.red;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's suboptimal...";
        }
        else if (_enemy.windType == true)
        {
            _enemy.TakeDamage(_dmgAmount / 2);
            _playerLog.color = Color.red;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's suboptimal...";
        }
        else
        {
            _enemy.TakeDamage(_dmgAmount);
            _playerLog.color = Color.white;
            _playerLog.text = "Flint used: " + _attackName;
        }

    } 
    public void Water(string _attackName, int _dmgAmount)
    {
        //water attacks crit on fire elementals
        _sfx.WaterSFX();

        if (_enemy.fireType == true)
        {
            _enemy.TakeDamage(_dmgAmount * 2);
            _playerLog.color = Color.green;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's effective!";
        }
        else if (_enemy.waterType == true)
        {
            _enemy.TakeDamage(_dmgAmount / 2);
            _playerLog.color = Color.red;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's suboptimal...";
        }
        else if (_enemy.windType == true)
        {
            _enemy.TakeDamage(_dmgAmount / 2);
            _playerLog.color = Color.red;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's suboptimal...";
        }
        else 
        {
            _enemy.TakeDamage(_dmgAmount);
        _playerLog.color = Color.white;
        _playerLog.text = "Flint used: " + _attackName;
        }
        } 
    public void Wind(string _attackName, int _dmgAmount)
    {
        //wind attacks crit on wind elementals
        _sfx.WindSFX();

        if (_enemy.windType == true)
        {
            _enemy.TakeDamage(_dmgAmount * 2);
            _playerLog.color = Color.green;
            _playerLog.text = "Flint used: " + _attackName + "\n...it's effective!";
        }
        else
        {
            _enemy.TakeDamage(_dmgAmount);
            _playerLog.color = Color.white;
            _playerLog.text = "Flint used: " + _attackName;
        }
        
    }
}
