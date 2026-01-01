using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPowerUp : MonoBehaviour

{
    //public GameObject pickupEffect;
    //public float multiplier = 1.4f;
    FingerMovement playerWeapon;
    enableGunPowerUp powerUpOn;
    GameSession gameSession;
    [SerializeField] int duration = 2;
   Rigidbody2D weaponRB;

   public void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.CompareTag("Player"))
      {
        
        StartCoroutine(Pickup(other)); 
        
      }
  }
  IEnumerator Pickup(Collider2D player)
  {   
    
    FingerMovement playerWeapon = player.GetComponent<FingerMovement>();
     enableGunPowerUp powerUpOn = player.GetComponent<enableGunPowerUp>();
    FindObjectOfType<GameSession>().powerupCounter++;
     
    weaponRB=GetComponent<Rigidbody2D>();
    weaponRB.constraints = RigidbodyConstraints2D.FreezePositionY;//grabs the RB of the powerup to freeze it so it doesn't fall into the bottom shredder so that it can complete the coroutine.
      //Instantiate(pickupEffect, transform.position, transform.rotation);//vfx
    //Disable the power up renderer and collider
   
           
    GetComponent<SpriteRenderer>().enabled = false;
    GetComponent<BoxCollider2D>().enabled = false;
    
      
      powerUpOn.enabled = true; //enables the script for the side guns to fire.
    
           
      yield return new WaitForSeconds(duration);
     
      
      
      
      if (powerUpOn!= null){//stops the "gameobject has been destroyed but you are still trying to access it, check if null or don't destroy gameobject"
      powerUpOn.enabled = false;
      }
      Destroy(gameObject);
     
    }
    
  }



