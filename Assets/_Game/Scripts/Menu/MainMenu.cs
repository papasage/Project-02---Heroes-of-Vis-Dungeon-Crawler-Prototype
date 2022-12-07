using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void DefaultRoomCount()
    {
        PlayerPrefs.SetInt("RoomGoal", 10);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnMainMenu()
    {
        PlayerPrefs.SetInt("RoomCount", 0);
        PlayerPrefs.SetInt("dmgMulti", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();

    }
}
