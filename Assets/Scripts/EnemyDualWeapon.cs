using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDualWeapon : MonoBehaviour
{
   [Header("Enemy Data/Stats")]
    [SerializeField] public float health = 100f;
    [SerializeField] int scoreValue = 150;
    [Header("Projectiles and Shooting")]
     float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] public float projectileSpeed = 10f;

      [SerializeField]float Xpadding = 0.4f;
    [Header("VFX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [Header("Audio")]
    [SerializeField] AudioClip laserShotSFX;
    [SerializeField][Range(0,1)] float laserShotSFXVolume; 
    [SerializeField] AudioClip deathSFX;
    [SerializeField][Range(0, 1)] float deathSFXVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
       CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if( shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
     GameObject laser1 = Instantiate(projectile,

                transform.position+new Vector3(Xpadding,0,0),

                Quaternion.identity) as GameObject;
          laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-projectileSpeed);
            GameObject laser2 = Instantiate(projectile,

                transform.position- new Vector3(Xpadding, 0, 0),

                Quaternion.identity) as GameObject;

           laser2.GetComponent<Rigidbody2D>().velocity =new Vector2(0,-projectileSpeed);
           AudioSource.PlayClipAtPoint(laserShotSFX,Camera.main.transform.position, laserShotSFXVolume);
    }
     private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();//scripts count as components, also uppercase for class/type and lower for variables.
       if (!damageDealer) { return;} // gives a null reference if not included due to how collisions work. 
       ProcessHit(damageDealer);
    }

    private void ProcessHit( DamageDealer damageDealer)// when process hit is called we need to know who the damageDealer is to pass it into process hit. It's a parameter, a requirement for that method to run when called.
    {
         health -= damageDealer.GetDamage();
         damageDealer.Hit();
         if(health <= 0)
        {
           Dead();
        }
    }
    private void Dead()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position, deathSFXVolume);
    }
}

