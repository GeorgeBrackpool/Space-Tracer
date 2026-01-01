using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPowerUp : MonoBehaviour
{
  public GameObject pickupEffect;
    //public float multiplier = 1.4f;
 
    FingerMovement playerHealth;
    GameSession gameSession;

    public int healthIncrease = 50;    
    void Awake() {
      playerHealth = FindObjectOfType<FingerMovement>();
      
    }
  private void OnTriggerEnter2D(Collider2D col) 
    {
      
      if (col.CompareTag("Player"))
      {
        FindObjectOfType<GameSession>().powerupCounter++;
          Destroy(gameObject);//destroy after pickup
          GetComponent<SpriteRenderer>().enabled = false;
          GetComponent<BoxCollider2D>().enabled = false;
          if( playerHealth.health < 500){
          playerHealth.health = playerHealth.health + healthIncrease;
          }
          
          
      }
      
  }

  }


