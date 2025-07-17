using System;
using System.Collections.Generic;
using UnityEngine;

public class GetToKnowLists : MonoBehaviour
{
    public List<int> numbers;
    
    public List<HighScoreData> highScoreDatas =  new();

    private void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            highScoreDatas.Add(new HighScoreData());
            highScoreDatas[i].name = "AA" +i;
            highScoreDatas[i].highScore = i;
        }
        
        
     /*   highScoreDatas.Add(new HighScoreData());
        highScoreDatas.Add(new HighScoreData());
        highScoreDatas[0].name = "Djuro";
        highScoreDatas[0].highScore = 22;
        highScoreDatas[1].name = "Stef";
        highScoreDatas[1].highScore = 55;
        */
       // numbers.Sort();
        //for (int i = numbers.Count - 1; i >= 0; i--)
       // {
       //     Debug.Log(numbers[i]);
      //  }
      //  for (int i = 0; i < numbers.Count; i++)
      //  {
          
       // }
    }
}
