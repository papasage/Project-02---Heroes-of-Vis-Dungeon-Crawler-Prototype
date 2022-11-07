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
    [SerializeField] float _attackDuration = 3f;
    [SerializeField] public float _idleDanceTime = .5f;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _enemyNameText;
    [SerializeField] SFXManager _sfx;
    public int enemyHealth;
    [SerializeField] Image _spriteRenderer;

    //ScriptableObject Containers
    public string enemyName;
    public Sprite portrait;
    public Sprite portrait2;
    public Sprite portraitAttack;
    public int enemyMaxHealth;
    
    public string attackname1;
    public int attackdmg1;

    public string attackname2;
    public int attackdmg2;
    
    public string attackname3;
    public int attackdmg3;
    
    public string attackname4;
    public int attackdmg4;

    [Header("Enemy Type")]
    [SerializeField] public bool fireType; 
    [SerializeField] public bool earthType; 
    [SerializeField] public bool waterType; 
    [SerializeField] public bool windType; 

    private void Start()
    {
        _enemyNameText.text = enemyName;
        enemyHealth = enemyMaxHealth;
        
    }

    
    public void TakeDamage(int _amount)
    {
        enemyHealth -= _amount;
    }

    public void Attack1()
    {
        StartCoroutine(AttackAnimation(_pauseDuration, portraitAttack));
        _sfx.SlashSFX();
        StartCoroutine(PrintLog(_attackDuration, attackname1));
        _player.TakeDamage(attackdmg1);
    } 
    public void Attack2()
    {
        StartCoroutine(AttackAnimation(_pauseDuration, portraitAttack));
        _sfx.SlashSFX();
        StartCoroutine(PrintLog(_attackDuration, attackname2));
        _player.TakeDamage(attackdmg2);
    }
    public void Attack3()
    {
        StartCoroutine(AttackAnimation(_pauseDuration, portraitAttack));
        _sfx.SlashSFX();
        StartCoroutine(PrintLog(_attackDuration, attackname3));
        _player.TakeDamage(attackdmg3);
    }
    public void Attack4()
    {
        StartCoroutine(AttackAnimation(_pauseDuration, portraitAttack));
        _sfx.SlashSFX();
        StartCoroutine(PrintLog(_attackDuration, attackname4));
        _player.TakeDamage(attackdmg4);
    }

    IEnumerator PrintLog(float pauseDuration, string attackName)
    {
        //ENEMY THINKING START
        _enemyLog.gameObject.SetActive(true);
        _enemyLog.text = enemyName + " uses " + attackName + "!"; 
        //this is where the enemy will choose attack 1 or 2

        yield return new WaitForSeconds(pauseDuration);
        _enemyLog.gameObject.SetActive(false);
        //ENEMY THINKING END
    }

    public IEnumerator IdleDance(float _danceTime, Sprite idle1, Sprite idle2)
    {
        while (true) 
        { 
        _spriteRenderer.sprite = idle1;
        yield return new WaitForSeconds(_danceTime);
        _spriteRenderer.sprite = idle2;
        yield return new WaitForSeconds(_danceTime);
        }
    }

    IEnumerator AttackAnimation (float _attackTime, Sprite _attack)
    {
        _spriteRenderer.sprite = _attack;
        yield return new WaitForSeconds(_attackTime);
        StartCoroutine(IdleDance( _idleDanceTime, portrait, portrait2));
    }

    private void Update()
    {
        _healthText.text = "Health: " + enemyHealth.ToString();
        
        if (enemyHealth <= 0)
        {
            _spriteRenderer.gameObject.SetActive(false);
            _healthText.color = Color.red;
            _healthText.text = "VANQUISHED";
            _enemyLog.gameObject.SetActive(true);
            _enemyLog.text = enemyName + " has died!";
        }
    }

  
}
