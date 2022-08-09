using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Configuration")]
public class WaveConfig : ScriptableObject
{
   [SerializeField] GameObject enemyPrefab;
   [SerializeField] GameObject pathPrefab;
   [SerializeField] float timeBetweenSpawns = 0.5f;
   [SerializeField] float spawnRandomFactor = 0.3f;
   [SerializeField] int numberOfEnemies = 10;
   [SerializeField] float moveSpeed = 2f;

   public GameObject GetEnemyPrefab(){return enemyPrefab;}

   public List<Transform> GetWaypoints()
   {
      var wavewaypoints = new List<Transform>();
      foreach(Transform child in pathPrefab.transform)//for each child in the pathprefab
      {
         wavewaypoints.Add(child);//add each child and it's transform into the list wavewaypoints. 
      }
      
      return wavewaypoints;// returning wavewaypoints within the path prefab.
   }
   public float GettimeBetweenSpawns(){return timeBetweenSpawns;}
   public float GetspawnRandomFactor(){return spawnRandomFactor;}
   public int GetnumberOfEnemies(){return numberOfEnemies;}
   public float GetmoveSpeed(){return moveSpeed;}

}
