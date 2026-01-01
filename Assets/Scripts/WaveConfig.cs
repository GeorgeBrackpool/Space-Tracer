using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Configuration")]
public class WaveConfig : ScriptableObject
{
   [SerializeField] GameObject enemyPrefab;
   [SerializeField] GameObject pathPrefab;
   [SerializeField] public float timeBetweenSpawns = 0.5f;
   [SerializeField] public float spawnRandomFactor = 0.1f;
   [SerializeField] public float minimumSpawnTime = 0.2f;
   [SerializeField] public int numberOfEnemies = 10;
   [SerializeField] public float moveSpeed = 2f;

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

   public float GetRandomSpawnTime()
   {
      float spawnTime = Random.Range(timeBetweenSpawns - spawnRandomFactor, 
                                       timeBetweenSpawns + spawnRandomFactor);

      return Mathf.Clamp(timeBetweenSpawns, minimumSpawnTime, float.MaxValue);
   }
}
