using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Data/Stats")]
    [SerializeField] public float health = 100f;
    [SerializeField] int scoreValue = 150;
    [Header("Projectiles and Shooting")]
     float shotCounter;
    [SerializeField] public float minTimeBetweenShots = 0.2f;
    [SerializeField] public float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] public float projectileSpeed = 10f;
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
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
        ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserShotSFX,Camera.main.transform.position, laserShotSFXVolume);
    }
     void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();//scripts count as components, also uppercase for class/type and lower for variables.
       if (!damageDealer) { return;} // gives a null reference if not included due to how collisions work. 
       ProcessHit(damageDealer);
    }

     void ProcessHit( DamageDealer damageDealer)// when process hit is called we need to know who the damageDealer is to pass it into process hit. It's a parameter, a requirement for that method to run when called.
    {
         health -= damageDealer.GetDamage();
         damageDealer.Hit();
         if(health <= 0)
        {
           Dead();
        }
    }
    public void Dead()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        FindObjectOfType<GameSession>().enemiesDestroyedCounter++;//CloudOnceAchievements
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position, deathSFXVolume);
    }
}
