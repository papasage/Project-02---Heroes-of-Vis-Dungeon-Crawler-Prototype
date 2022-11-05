using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource SFXPlayer;
    [SerializeField] AudioClip _monsterCry;

    //Attacks
    [SerializeField] AudioClip _fireAttack;
    [SerializeField] AudioClip _earthAttack;
    [SerializeField] AudioClip _waterAttack;
    [SerializeField] AudioClip _windAttack;
    [SerializeField] AudioClip _slashAttack;


    private void Awake()
    {
        SFXPlayer = GetComponent<AudioSource>();
    }

    public void MonsterCrySFX()
    {
        //called in SetupState. currently disabled
        SFXPlayer.clip = _monsterCry;
        SFXPlayer.loop = false;
        SFXPlayer.Play();
    }
    public void FireSFX()
    {
        SFXPlayer.clip = _fireAttack;
        SFXPlayer.loop = false;
        SFXPlayer.Play();
    }
    public void EarthSFX()
    {
        SFXPlayer.clip = _earthAttack;
        SFXPlayer.loop = false;
        SFXPlayer.Play();
    } 
    public void WaterSFX()
    {
        SFXPlayer.clip = _waterAttack;
        SFXPlayer.loop = false;
        SFXPlayer.Play();
    } 
    public void WindSFX()
    {
        SFXPlayer.clip = _windAttack;
        SFXPlayer.loop = false;
        SFXPlayer.Play();
    } 
    public void SlashSFX()
    {
        SFXPlayer.clip = _slashAttack;
        SFXPlayer.loop = false;
        SFXPlayer.Play();
    }
}
