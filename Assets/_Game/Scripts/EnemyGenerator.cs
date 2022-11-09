using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] EnemyData[] enemies;
    [SerializeField] EnemyData[] bosses;
    EnemyData _chosenEnemy;
    int index;

    public void GenerateEnemy()
    {
        //select enemydata asset from a list at random
        index = Random.Range(0, enemies.Length);
        
        _chosenEnemy = enemies[index];

        EnemyAppear(_chosenEnemy);
    }

    public void GenerateBoss()
    {
        index = Random.Range(0, bosses.Length);

        _chosenEnemy = bosses[index];

        EnemyAppear(_chosenEnemy);
    }

    private void EnemyAppear(EnemyData enemyData)
    {
        _enemy.enemyName = enemyData.enemyName;
        _enemy.portrait = enemyData.portrait;
        _enemy.portrait2 = enemyData.portrait2;
        _enemy.portraitAttack = enemyData.portraitAttack;
        _enemy.enemyMaxHealth = enemyData.enemyHealth;
        _enemy.attackname1 = enemyData.attack1Name;
        _enemy.attackdmg1 = enemyData.attack1Damage;
        _enemy.attackname2 = enemyData.attack2Name;
        _enemy.attackdmg2 = enemyData.attack2Damage;
        _enemy.attackname3 = enemyData.attack3Name;
        _enemy.attackdmg3 = enemyData.attack3Damage;
        _enemy.attackname4 = enemyData.attack4Name;
        _enemy.attackdmg4 = enemyData.attack4Damage;
        _enemy.fireType = enemyData.fireType;
        _enemy.earthType = enemyData.earthType;
        _enemy.waterType = enemyData.waterType;
        _enemy.windType = enemyData.windType;
    }
}
