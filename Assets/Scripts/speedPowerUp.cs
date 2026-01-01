using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPowerUp : MonoBehaviour
{
      Movement playerSpeed;
    
    
    [SerializeField] int duration = 4;
  Rigidbody2D speedRB;

   public void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.CompareTag("Player"))
      {
        StartCoroutine(Pickup(other)); 
      }
  }
  IEnumerator Pickup(Collider2D player)
  {   
    
    Movement playerSpeed = player.GetComponent<Movement>();
     
    
     
    speedRB=GetComponent<Rigidbody2D>();
    speedRB.constraints = RigidbodyConstraints2D.FreezePositionY;//grabs the RB of the powerup to freeze it so it doesn't fall into the bottom shredder so that it can complete the coroutine.
      //Instantiate(pickupEffect, transform.position, transform.rotation);//vfx
    //Disable the power up renderer and collider
   
           
    GetComponent<SpriteRenderer>().enabled = false;
    GetComponent<BoxCollider2D>().enabled = false;
    
      
      
            playerSpeed.moveSpeed = 8f;
           
      yield return new WaitForSeconds(duration);
      // maybe remove this checking for error.
       
        
      playerSpeed.moveSpeed = 5.5f;
      
      
      
      
      Destroy(gameObject);
     
    }
}
