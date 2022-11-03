using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] PlayerHealth _player;
    [SerializeField] Text _enemyLog;
    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _enemyNameText;

    //ScriptableObject Containers
    public string enemyName;
    public int enemyHealth;
    public int enemyDamage1;
    public int enemyDamage2;

    private void Start()
    {
        _enemyNameText.text = enemyName;
    }
    public void TakeDamage(int _amount)
    {
        enemyHealth -= _amount;
    }

    public void Attack1()
    {
        StartCoroutine(PrintLog(_pauseDuration,"Attack1"));
        _player.TakeDamage(enemyDamage1);
    } 
    public void Attack2()
    {
        StartCoroutine(PrintLog(_pauseDuration, "Attack2"));
        _player.TakeDamage(enemyDamage2);
    }

    IEnumerator PrintLog(float pauseDuration, string attackName)
    {
        //ENEMY THINKING START
        _enemyLog.gameObject.SetActive(true);
        _enemyLog.text = "Enemy attacks with " + attackName + "!"; 
        //this is where the enemy will choose attack 1 or 2

        yield return new WaitForSeconds(pauseDuration);
        _enemyLog.gameObject.SetActive(false);
        //ENEMY THINKING END
    }

    private void Update()
    {
        _healthText.text = "Health: " + enemyHealth.ToString();
        
        if (enemyHealth <= 0)
        {
            _healthText.color = Color.red;
            _healthText.text = "VANQUISHED";
            _enemyLog.gameObject.SetActive(true);
            _enemyLog.text = enemyName + " has died!";
        }
    }
}
