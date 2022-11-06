using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomProgression : MonoBehaviour
{
    [SerializeField] PlayerHealth _playerHealth;

    [SerializeField] public int roomCount = 0;
    [SerializeField] public int prevHealth;


    public void NewRoom()
    {
        roomCount = PlayerPrefs.GetInt("RoomCount");
        roomCount++;
        PlayerPrefs.SetInt("RoomCount", roomCount);
        PlayerPrefs.Save();
    }

    public void ResetRooms()
    {
        roomCount = 0;
        PlayerPrefs.SetInt("RoomCount", roomCount);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        ResetRooms();
    }
}
