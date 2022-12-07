using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] public int damageMultiplier = 1;
    [SerializeField] TextMeshProUGUI _damageTxt;

    private void Awake()
    {
        damageMultiplier = PlayerPrefs.GetInt("dmgMulti",1);
    }

    private void Update()
    {
        _damageTxt.text = "Damage: x" + damageMultiplier.ToString();

        if (Input.GetKeyDown(KeyCode.D))
        {
            IncreaseDamage(1);
        }
    }
    public void IncreaseDamage(int amount)
    {
        damageMultiplier = PlayerPrefs.GetInt("dmgMulti");
        damageMultiplier += amount;
        PlayerPrefs.SetInt("dmgMulti", damageMultiplier);
        PlayerPrefs.Save();
    }

    public void ResetDamage()
    {
        damageMultiplier = 1;
        PlayerPrefs.SetInt("dmgMulti", damageMultiplier);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        ResetDamage();
    }
}
