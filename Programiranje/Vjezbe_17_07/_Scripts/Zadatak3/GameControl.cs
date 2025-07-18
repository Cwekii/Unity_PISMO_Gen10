using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    [SerializeField] private int coinNumber;
    
    [SerializeField] private TMP_Text scoreText;
    private int score;
    //Imovina /prevedi na eng
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            Debug.Log($"Score: {score}");
            scoreText.text = score.ToString();
            CheckHighScore();
            if (score == 5)
            {
              Debug.Log("WIN!!!!!!");  
            }
        }
    }
    
    private int highScore;
  [SerializeField]  private float timer = 2f;
    
    [SerializeField]  List<Coin> coins = new List<Coin>();

    private void Awake()
    {
        Instance =  this;
    }

    private void Start()
    {
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log($"Game over");
        }
    }

    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            Debug.Log("High score: " + highScore);
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }
    
}
