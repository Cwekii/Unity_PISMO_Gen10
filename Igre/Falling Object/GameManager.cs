using System;
using TMPro;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{[Header("Prefabs")]
    [SerializeField] private FallingObject[] prefab;
    [Header("Player movement")] [Tooltip("Reference to player movement so it should always be in scene")] 
  [SerializeField] private PlayerMovement playerMovement;
    
    [Header("UI")] [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    

    private int score = 0;
    private int lives = 3;
    private int increaseLivesCounter = 0;

[HideInInspector] public  Coroutine coroutine;

private void Start()
{
    gameOverPanel.SetActive(false);
    livesText.text = $"Lives: {lives}";
}

// Coroutine that spawns falling objects ( prefabs) every 1 second
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        Debug.Log($"Start game coroutine");
        RandomSpawnPoint();
        yield return StartGame();

    }

    // choosing randim distance on x-axis with min and max float
    private float RandomDistanceX()
    {
      return Random.Range(-6.748f,-10.64f);
    }
    

    // spawning random prefab from the list on random x-axis 
    private void RandomSpawnPoint()
    {
       Instantiate(prefab[RandomIndex()], new Vector3(RandomDistanceX(), 8,-15.3482f), Quaternion.identity);
    }
    public void ReduceLive()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
        if (lives == 0)
        {
            gameOverPanel.SetActive(true);
            StopCoroutine(coroutine);
            Debug.Log("Game Over");
        }
    }
    private void CanIncreaseLife()
    {
        increaseLivesCounter++;
        if (increaseLivesCounter >= 30)
        {
            increaseLivesCounter = 0;
            lives++;
            livesText.text = $"Lives: {lives}";
        }
        
    }
    
    // chooses random number between 0 and size of array
    private int RandomIndex()
    {
        return Random.Range(0, prefab.Length);
    }
    // Increases score for amount received from falling object
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        if (amount > 0)
        {
            CanIncreaseLife();
        }
    }

    // restarts whole game and resets game state
    public void RestartGame()
    {
        //TODO: reset score, lives and increaseLivesCounter
        ResetGameState();
        PlayGame();
    }

    // plays game
    public void PlayGame()
    {
        // starting spawning
      coroutine = StartCoroutine(StartGame());
      
        // deactivate main menu panel
        mainMenuPanel.SetActive(false);
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
    }
    // resets score to 0, lives to 3 and increaseLivesCounter to 0, and updates text
    public void ResetGameState()
    {
        gameOverPanel.SetActive(false);
        score = 0;
        lives = 3;
        increaseLivesCounter = 0;
        scoreText.text = $"Score: {score}";
        livesText.text = $"Lives: {lives}";
    }
}


