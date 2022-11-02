using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource MusicPlayer;
    [SerializeField] AudioClip _battleMusic;
    [SerializeField] AudioClip _bossBattleMusic;
    [SerializeField] AudioClip _victoryMusic;
    [SerializeField] AudioClip _defeatMusic;
    

    private void Start()
    {
        MusicPlayer = GetComponent<AudioSource>();
    }

    public void BattleMusic()
    {
        MusicPlayer.clip = _battleMusic;
        MusicPlayer.loop = true;
        MusicPlayer.Play();
    }
    public void BossBattleMusic()
    {
        MusicPlayer.clip = _bossBattleMusic;
        MusicPlayer.loop = true;
        MusicPlayer.Play();
    }
    public void VictoryMusic()
    {
        MusicPlayer.clip = _victoryMusic;
        MusicPlayer.loop = false;
        MusicPlayer.Play();
    }
    public void DefeatMusic()
    {
        MusicPlayer.clip = _defeatMusic;
        MusicPlayer.loop = true;
        MusicPlayer.Play();
    }
}
