using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   [SerializeField] private TMP_Text scoreText;
   
   
   private float score;


   private void Awake()
   {
      Instance = this;
   }

   private void Start()
   {
      scoreText.text = $"Score: {score}";
   }

   public void IncreaseScore()
   {
      score++;
      scoreText.text = $"Score: {score}";
      
   }
}
