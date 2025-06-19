using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerScore", 100);
        PlayerPrefs.SetString("PlayerName", "John");
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        int score = PlayerPrefs.GetInt("PlayerScore");
        string playerName = PlayerPrefs.GetString("PlayerName");
        Debug.Log("Player Score: " + score);
        Debug.Log("Player Name: " + playerName);
    }
}