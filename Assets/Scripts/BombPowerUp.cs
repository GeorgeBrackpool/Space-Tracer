using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPowerUp : MonoBehaviour
{
     Enemy getEnemyClass;

     private void Awake() {
        getEnemyClass = FindObjectOfType<Enemy>();
     }
      private void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.CompareTag("Player"))
      {
       FindObjectOfType<GameSession>().powerupCounter++;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        DestroyAllEnemiesInScene("Enemy");
        DestroyAllEnemiesInScene("EnemyDual");
      }
    }

    void DestroyAllEnemiesInScene(string tagname)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemyDual = GameObject.FindGameObjectsWithTag("EnemyDual");

        foreach(GameObject Enemy in enemies)
        {
          Enemy.gameObject.GetComponent<Enemy>().Dead();

        }
         foreach(GameObject Enemy in enemyDual)
        {
          Enemy.gameObject.GetComponent<Enemy>().Dead();

        }                 
    }

}
