using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource SFXPlayer;
    [SerializeField] AudioClip _monsterCry;


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
}
