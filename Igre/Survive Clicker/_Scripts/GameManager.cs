using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // poopulation, wood, gold, food, stone, iron, tools, 
   // resources
   [Header("Resources")] [SerializeField] private int days; // done
   [SerializeField] private int workers; //done
   [SerializeField] private int unemployed; // done
   [SerializeField] private int wood; // done
   [SerializeField] private int stone;
   [SerializeField] private int iron;
   [SerializeField] private int gold;
   [SerializeField] private int food; // done
   [SerializeField] private int tools;
   [SerializeField] private Image dayImage;
   
   [Header("Building")]
   // farm, house, iron mines,gold mines, woodcutter, blacksmith, quarry

   [SerializeField]
   private int house; // done

   [SerializeField] private int farm; // done
   [SerializeField] private int woodcutter; // done
   [SerializeField] private int blacksmith;
   [SerializeField] private int quarry;
   [SerializeField] private int ironMines;
   [SerializeField] private int goldMines;
   
   [Header("Resources Text")] [SerializeField]
   private TMP_Text daysText;
   [SerializeField] private TMP_Text poopulationText;
   [SerializeField] private TMP_Text woodText;
   [SerializeField] private TMP_Text foodText;
   [SerializeField] private TMP_Text ironText;
   
   [Header("Building text")] [SerializeField]
   private TMP_Text houseText;
   [SerializeField] private TMP_Text farmText;
   [SerializeField] private TMP_Text woodcutterText;
   
   [SerializeField] private TMP_Text notificationText;
   bool isGameRunning = false;

   
   

   private float timer;


   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha0))
      {
         Time.timeScale = 0;
      }
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         Time.timeScale = 1;
      } 
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         Time.timeScale = 2;
      } 
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
         Time.timeScale = 4;
      }
      // one minute is one day
      TimeOfDay();
   }

   private void TimeOfDay()
   {
      if (!isGameRunning)
      {
         return;
      }
      timer += Time.deltaTime;
      dayImage.fillAmount = timer / 60;
      if (timer >= 60)
      {
         days++;
         FoodGathering();
         FoodProduction();
         WoodProduction();
         FoodConsumption(1);
         IncreasePoopulation();
         UpdateText();
         timer = 0;
      }
   }

   public void InitializeGame()
   {
      isGameRunning = true;
      UpdateText();
   }

   private void IncreasePoopulation()
   {
      if (days % 2 == 0)
      {
         if (GetMaxPoopulation() > Poopulation())
         {
            unemployed += house;
            if (GetMaxPoopulation() < Poopulation())
            {
               unemployed = GetMaxPoopulation() - workers;
            }
         }
      }
   }

   private int Poopulation()
   {
      return workers + unemployed;
   }

   private void FoodConsumption(int foodConsumed)
   {
      food -= foodConsumed * Poopulation();
      if (food < 0)
      {
         unemployed += food; 
         food = 0;
      }
   }

   private void FoodGathering()
   {
      food += unemployed / 2;
   }

   private void FoodProduction()
   {
      food += farm * 4;
   }
   private void WoodProduction()
   {
      wood += woodcutter * 2;
   }

   // number of max house * 4 
   private int GetMaxPoopulation()
   {
      int maxPoopulation = house * 4;
      return maxPoopulation;
   }
   private void WorkerAssign(int amount)
   {
      unemployed -= amount;
      workers += amount;
   }

   private bool CanAssignWorker(int amount)
   {
      return unemployed >= amount;
   }

   public void BuildHouse()
   {
      if (wood >= 2)
      {
         wood -= 2;
         house++;
         UpdateText();
      }
      else
      {
         string text = $"You need more {2 - wood} wood";
         StartCoroutine(NotificationText(text));
      }
   }

   public void BuildFarm()
   {
      // izgradi se farma
      if (wood >= 10 && CanAssignWorker(2))
      {
         wood -= 10;
         farm++;
         WorkerAssign(2);
         UpdateText();
      }

      else
      {
         string text = $"You need more {10 - wood} wood  or {2 - unemployed} people";
         StartCoroutine(NotificationText(text));
      }
   }

   public void BuildWoodCutter()
   {
      if (wood >= 5 && iron > 0 && CanAssignWorker(1))
      {
         iron--;
         wood -= 5;
         WorkerAssign(1);
         woodcutter++;
         UpdateText();
         string text = $"You have built wood cutters hut";
         StartCoroutine(NotificationText(text));
      }
      else
      {
         string text = $"You need more {5 - wood} wood or {1 - iron} iron or {1 - unemployed} people";
         StartCoroutine(NotificationText(text));
      }
      
   }

   private void UpdateText()
   {
      daysText.text = days.ToString();
      //resources
      poopulationText.text = $"{Poopulation()}/{GetMaxPoopulation()}\n    Workers:{workers}\n     Unemployed:{unemployed}";
      foodText.text = $"{food}";
      woodText.text = wood.ToString();
      ironText.text = $"Iron: {iron}";
      
      //Buildings
      farmText.text = $"Farm: {farm}";
      houseText.text = $"House: {house}";
      woodcutterText.text = $"Wood Cutter: {woodcutter}";
   }
   
   //TODO: Make this method a class
   private void BuildCost(int woodCost, int stoneCost, int workerAssign)
   {
      if (wood >= woodCost && stone >= stoneCost && unemployed >= workerAssign)
      {
         wood -= woodCost;
         stone -= stoneCost;
         unemployed -= workerAssign;
         workers += workerAssign;
      }
   }

   IEnumerator NotificationText(string text)
   {
      notificationText.text = text;
      yield return new WaitForSeconds(2);
      notificationText.text = String.Empty;
   }
}
