using System;
using UnityEngine;

public static class SaveSystem
{
    private const string HIGHSCORE_KEY = "HIGHSCORE";

    public static void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
        PlayerPrefs.Save();
    }
    public static void SaveHighScore(string nameKey,int score)
    {
        PlayerPrefs.SetInt(nameKey, score);
        PlayerPrefs.Save();
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY);
    } 
    
    public static int GetHighScore(string nameKey)
    {
        return PlayerPrefs.GetInt(nameKey);
    }
    
    
}
