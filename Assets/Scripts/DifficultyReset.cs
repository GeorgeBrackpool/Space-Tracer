using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyReset : MonoBehaviour
{
    /* This Class Resets all the values permanently changed 
     in the ScalingDifficulty class upon the game starting. */

     [SerializeField] float originalHealth = 100;
     [SerializeField] float originalProjectileSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
      ResetEnemyProjectileDamage();
      ResetEnemyStats();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetEnemyProjectileDamage()
    {
      foreach(GameObject laser in FindObjectOfType<ScalingDifficulty>().lasers)
        {
            if(laser.CompareTag("Enemy Projectile"))
            {
               laser.GetComponent<DamageDealer>().damage = 100;
            }
            if(laser.CompareTag("EnemyBomb1"))
            {
               laser.GetComponent<DamageDealer>().damage = 150;
            }
            if(laser.CompareTag("EnemyBomb2"))
            {
               laser.GetComponent<DamageDealer>().damage = 200;
            }
            if(laser.CompareTag("EnemyBomb3"))
            {
               laser.GetComponent<DamageDealer>().damage = 250;
            }
            if(laser.CompareTag("EnemyBomb4"))
            {
               laser.GetComponent<DamageDealer>().damage = 300;
            }
        }
    }
     void ResetEnemyStats()
        {
         foreach(GameObject enemy in FindObjectOfType<ScalingDifficulty>().enemyShips)
         {
            if(enemy.CompareTag("EnemyDual"))
            {
               enemy.GetComponent<EnemyDualWeapon>().health = originalHealth;
               enemy.GetComponent<EnemyDualWeapon>().projectileSpeed = originalProjectileSpeed;
            }
            if(enemy.CompareTag("Enemy"))
            {
               enemy.GetComponent<Enemy>().health = originalHealth;
               enemy.GetComponent<Enemy>().projectileSpeed = originalProjectileSpeed;
            }
            
             if(enemy.CompareTag("EnemyBoss1"))
            {
               enemy.GetComponent<Enemy>().health = 500;
               enemy.GetComponent<Enemy>().projectileSpeed = 2;
            }
            if(enemy.CompareTag("EnemyBoss2"))
            {
               enemy.GetComponent<Enemy>().health = 500;
               enemy.GetComponent<Enemy>().projectileSpeed = 4;
            }
            if(enemy.CompareTag("EnemyBoss3"))
            {
               enemy.GetComponent<Enemy>().health = 500;
               enemy.GetComponent<Enemy>().projectileSpeed = 4;
            }
            if(enemy.CompareTag("EnemyBoss4"))
            {
               enemy.GetComponent<Enemy>().health = 800;
               enemy.GetComponent<Enemy>().projectileSpeed = 7;
            }
            if(enemy.CompareTag("EnemyFinalBoss"))
            {
               enemy.GetComponent<EnemyDualWeapon>().health = 1500;
               enemy.GetComponent<EnemyDualWeapon>().projectileSpeed = 10;
            }
         }
      }
}
