using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratefirePowerUp : MonoBehaviour
{
     FingerMovement playerMaxRate;
     FingerMovement playerMinRate;
    
      GameSession gameSession;
    
    [SerializeField] int duration = 5;
  Rigidbody2D rateRB;

   public void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.CompareTag("Player"))
      {
        
        StartCoroutine(Pickup(other)); 
        
      }
  }
  IEnumerator Pickup(Collider2D player)
  {   
    
    FingerMovement playerMaxRate = player.GetComponent<FingerMovement>();
    FingerMovement playerMinRate = player.GetComponent<FingerMovement>();
     FindObjectOfType<GameSession>().powerupCounter++;
    
     
    rateRB=GetComponent<Rigidbody2D>();
    rateRB.constraints = RigidbodyConstraints2D.FreezePositionY;//grabs the RB of the powerup to freeze it so it doesn't fall into the bottom shredder so that it can complete the coroutine.
      //Instantiate(pickupEffect, transform.position, transform.rotation);//vfx
    //Disable the power up renderer and collider
   
           
    GetComponent<SpriteRenderer>().enabled = false;
    GetComponent<BoxCollider2D>().enabled = false;
    
      
      
            playerMaxRate.maxTimeBetweenShots = 0.4f;
            playerMinRate.minTimeBetweenShots = 0.2f;
           
      yield return new WaitForSeconds(duration);
     
       
        
        playerMaxRate.maxTimeBetweenShots = 1.5f;
        playerMinRate.minTimeBetweenShots = 0.5f;
      
      
      
      
      Destroy(gameObject);
     
    }
}

