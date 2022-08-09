using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    public  GameObject[] spawnObjects;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
         screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * -1, Camera.main.transform.position.z));
        StartCoroutine(powerUpWave());
       
    }
   private void SpawnpowerUp()
   {
      //Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], this.transform);
      GameObject a = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)]);
       a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * -1);

   }
    IEnumerator powerUpWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            SpawnpowerUp();
        }
    }
}