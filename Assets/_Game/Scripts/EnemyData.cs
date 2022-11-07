using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy_")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Name")]
    [SerializeField] public string enemyName = "...";

    [SerializeField] public enum ElementalType { Fire, Earth, Water, Wind }

    [Header("Enemy Sprite Portrait")]
    [SerializeField] public Sprite portrait = null;
    [SerializeField] public Sprite portrait2 = null;
    [SerializeField] public Sprite portraitAttack = null;

    [Header("Enemy HP")]
    [SerializeField] public int enemyHealth = 1;

    [Header("Enemy Type")]
    [SerializeField] public bool fireType; 
    [SerializeField] public bool earthType; 
    [SerializeField] public bool waterType; 
    [SerializeField] public bool windType; 

    [Header("Attack #1")]
    [SerializeField] public string attack1Name = "SLASH";
    [SerializeField] public int attack1Damage = 1;

    [Header("Attack #2")]
    [SerializeField] public string attack2Name = "BASH";
    [SerializeField] public int attack2Damage = 2;

    [Header("Attack #3")]
    [SerializeField] public string attack3Name = "CRASH";
    [SerializeField] public int attack3Damage = 3;

    [Header("Attack #4")]
    [SerializeField] public string attack4Name = "SMASH";
    [SerializeField] public int attack4Damage = 4;

}
