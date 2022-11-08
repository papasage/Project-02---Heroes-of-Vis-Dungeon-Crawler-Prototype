using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyInput : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputField;
    string _inputString;

    

    public void SaveDifficulty()
    {
        _inputString = _inputField.text;
        InputDifficulty(_inputString);
    }

    public void InputDifficulty(string _input)
    {
        int.TryParse(_input, out int _RoomGoal);
        PlayerPrefs.SetInt("RoomGoal", _RoomGoal);
    }
}
