 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScalingDifficulty : MonoBehaviour
{   
    /* This Class increases the difficulty of the game after each time the last boss ship Big Boss 5 Spawns. Some of the code in the co-routine changes Unity component values
    which persists after run-time. To see how these values are reset when the game restarts see the "DifficultyReset.cs" class. */
    EnemySpawner enemySpawner;
    WaveConfig waveconfigs;
    bool BigBossActive;
    DamageDealer damageDealer;
    public GameObject[] lasers;
    [SerializeField] public GameObject[] enemyShips;
    [SerializeField] int EnemyDamageIncrement;
    Enemy enemies;
    [SerializeField] float difficultyHealthIncrease;
    [SerializeField] float projectileSpeedIncrease;

    // Start is called before the first frame update
    void Start()
    {
      waveconfigs = FindObjectOfType<WaveConfig>();
      enemySpawner = FindObjectOfType<EnemySpawner>();
      damageDealer = FindObjectOfType<DamageDealer>();
      enemies = FindObjectOfType<Enemy>();
    }
    private void Awake() 
    {
      
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      
        StartCoroutine(BigBossIncrease());
    }
    IEnumerator BigBossIncrease()
    {
      if(GameObject.Find("Big Boss 5(Clone)") && !BigBossActive)
      {
        
        Debug.Log("Big Boss increase");
          BigBossActive = true;
          foreach(GameObject laser in lasers)
          {
            laser.GetComponent<DamageDealer>().damage += EnemyDamageIncrement;
          }
          foreach(GameObject enemy in enemyShips)
          {
            if(enemy.tag == "Enemy")
            {
                enemy.GetComponent<Enemy>().health += difficultyHealthIncrease;
                enemy.GetComponent<Enemy>().projectileSpeed += projectileSpeedIncrease;
            }
            if(enemy.tag == "EnemyDual")
            {
               enemy.GetComponent<EnemyDualWeapon>().health += difficultyHealthIncrease;
               enemy.GetComponent<EnemyDualWeapon>().projectileSpeed += projectileSpeedIncrease;
            }
              if(enemy.CompareTag("EnemyBoss1"))
            {
                enemy.GetComponent<Enemy>().health += difficultyHealthIncrease;
                enemy.GetComponent<Enemy>().projectileSpeed += projectileSpeedIncrease;
            }
            if(enemy.CompareTag("EnemyBoss2"))
            {
              enemy.GetComponent<Enemy>().health += difficultyHealthIncrease;
              enemy.GetComponent<Enemy>().projectileSpeed += projectileSpeedIncrease;
            }
            if(enemy.CompareTag("EnemyBoss3"))
            {
              enemy.GetComponent<Enemy>().health += difficultyHealthIncrease;
              enemy.GetComponent<Enemy>().projectileSpeed += projectileSpeedIncrease;
            }
            if(enemy.CompareTag("EnemyBoss4"))
            {
              enemy.GetComponent<Enemy>().health += difficultyHealthIncrease;
              enemy.GetComponent<Enemy>().projectileSpeed += projectileSpeedIncrease;
            }
            if(enemy.tag == "EnemyFinalBoss")
            {
               enemy.GetComponent<EnemyDualWeapon>().health += difficultyHealthIncrease;
               enemy.GetComponent<EnemyDualWeapon>().projectileSpeed += projectileSpeedIncrease;
            }
            
          }
           /* If I ever want to change the Scriptable object values in future then the code below works.
           foreach (WaveConfig wave in enemySpawner.waveConfigs)
           {
            wave.timeBetweenSpawns += 2f;
           }*/
          yield return null;
      }
      if(GameObject.Find("Big Boss 5(Clone)") == null && BigBossActive)
        {
          
          Debug.Log("Big Boss Not active");
           BigBossActive = false;
          yield return null;
        }
       
      }
}
