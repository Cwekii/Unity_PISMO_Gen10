using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_InputField usernameInput;
    
    private const string SCORE_KEY = "scoreKey";
    private const string HIGHSCORE_KEY = "highScoreKey";
    private const string USERNAME_KEY = "usernameKey";
    
    private string username;
    private int score;
    
    [SerializeField] List<int> highScores;
    public List<HighScoreData> highScoreDatas =  new();

   // SaveSystem saveSystem =  new SaveSystem(); // creating object of this class

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            highScoreDatas.Add(new HighScoreData());
            //TODO: Provjeriti da li imamo sta save-ano u PlayerPrefs
            highScoreDatas[i].highScore = SaveSystem.GetHighScore();
        }
        
        score = PlayerPrefs.GetInt(SCORE_KEY, 0);
        scoreText.text = $"Score: {score}";
        
      //  highScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
        username = PlayerPrefs.GetString(USERNAME_KEY);
        highScoreText.text = $"High Score: {SaveSystem.GetHighScore()}";
        // highScoreText.text = $"Username: {username}: High Score: {highScore}";
    }

    public void Increase()
    {
        score++;
        
        scoreText.text = $"Score: {score}";
    }

    public void Decrease()
    {
        score--;
        scoreText.text = $"Score: {score}";
    }

    public void SaveScore()
    {
        SaveSystem.SaveHighScore(score);
        
        PlayerPrefs.SetInt(SCORE_KEY, score);
        
        //if (score  > highScore)
        {
            SaveHighScore();
        }
        PlayerPrefs.Save();
    }

    private void SaveHighScore()
    {
        
        
        //highScore = score;
       // highScores.Add(highScore); // add element (int) to the list
        username = usernameInput.text;
        PlayerPrefs.SetString(USERNAME_KEY, username);
      //  PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore); // save last highscore
       // PlayerPrefs.SetInt(HIGHSCORE_KEY + highScore, 0);
        PlayerPrefs.Save();
    }
}
