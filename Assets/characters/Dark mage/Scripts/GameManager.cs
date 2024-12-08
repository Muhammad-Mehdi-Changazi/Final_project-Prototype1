using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public Transform player;
   public List<Enemy> enemiesList;
   public bool enemyArea1;
   public bool enemyArea2;
   public bool enemyArea3;
   public bool enemyArea4;

   public int enemyDieCount;
   public int focusedEnemyIndex;
   public float enemyDetectionRadius;
   public GameObject LevelWinPanel;

   private void Awake()
   {
      focusedEnemyIndex = 0;
   }

   private void Update()
   {
      if (Vector3.Distance(player.position, enemiesList[focusedEnemyIndex].transform.position ) <= enemyDetectionRadius)
      {
         enemyArea1 = true;
      }
      if (Vector3.Distance(player.position, enemiesList[focusedEnemyIndex+1].transform.position ) <= enemyDetectionRadius)
      {
         enemyArea2 = true;
      }
      if (Vector3.Distance(player.position, enemiesList[focusedEnemyIndex+2].transform.position ) <= enemyDetectionRadius)
      {
         enemyArea3 = true;
      }
      if (Vector3.Distance(player.position, enemiesList[focusedEnemyIndex+3].transform.position ) <= enemyDetectionRadius)
      {
         enemyArea4 = true;
      }
      
   }

   public bool GetEnemyBool(int enemyIndex)
   {
      if (enemyIndex == 1)
      {
         return enemyArea1;
      }
      else if (enemyIndex == 2)
      {
         return enemyArea2;
      }
      else if (enemyIndex == 3)
      {
         return enemyArea3;
      }
      else if (enemyIndex == 4)
      {
         return enemyArea4;
      }

      return false;
   }

   public void IncreaseEnemyDieCount()
   {
      enemyDieCount++;
      if (enemyDieCount == 4)
      {
         LevelWinPanel.SetActive(true);
      }
   }

   public void Retry()
   {
      SceneManager.LoadScene("GamePlay");
   }

   public Enemy GetClosetEnemy()
   {
      foreach (var enemy in enemiesList)
      {
         if (Vector3.Distance(player.position, enemy.transform.position) < 8f)
         {
            return enemy;
         }
      }

      return null;
   }

}
