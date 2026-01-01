using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Need to check for touches, get the touch then update transform of gameobject
public class FingerMovement : MonoBehaviour
{
   
    float deltaX;
    //float deltaY;

     Rigidbody2D rb;
    private Vector3 touchPosition;
    private Vector3 touchDirection;
    public BoxCollider2D col;
    public bool playerdead = false;
    
    [SerializeField] public int health = 500;
    [SerializeField] public float moveSpeed = 10f;
    //[SerializeField] int scoreValue = 5;
    
    [Header("Projectiles and Shooting")]
    float shotCounter;
    [SerializeField] public float minTimeBetweenShots = 0.2f;
    [SerializeField] public float maxTimeBetweenShots = 3f;
    [SerializeField] public GameObject projectile;
    [SerializeField] public float projectileSpeed = 10f;
    
    [Header("Audio and VFX")]
    //[SerializeField]public GameObject laserPrefab;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 3f;
    [SerializeField] public AudioClip laserShotSFX;
    [SerializeField][Range(0,1)]public  float laserShotSFXVolume; 
     [SerializeField] public AudioClip deathSFX;
    [SerializeField][Range(0, 1)] public float deathSFXVolume = 0.5f;
   
  
    
   
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        rb = GetComponent<Rigidbody2D> ();
        col = GetComponent<BoxCollider2D> ();
        //StartCoroutine(updateAliveScore());
    }
   
    private void FixedUpdate() {
        Finger();
         //Finger method better in here due to how unity handles physics objects.
    }
    // Update is called once per frame
    void Update()
    {
        
        
       CountDownAndShoot();
        
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);//Gets touch because touch count > 0
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
                //Get touch position from the screen touch to a world point.
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 15));
                //Now to Lerp and set position of the current touch and make it smooth movement over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }*/

        // This code leaves the ship where it is after you've finished touching and wont lerp to another point. Found it's a bit more annoying to control given that you have to constantly keep finger on the screen but could be good?
        //Have kept the code above commented if i ever want to switch back to the lerp and it hovers back to a finger thats touched screen somewhere else.
    }
    
    
     private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();//scripts count as components, also uppercase for class/type and lower for variables.
       if(!damageDealer){return;}
       ProcessHit(damageDealer);
    }
    
    private void ProcessHit( DamageDealer damageDealer)// when process hit is called we need to know who the damageDealer is to pass it into process hit. It's a parameter, a requirement for that method to run when called.
    {
         health -= damageDealer.GetDamage();
         damageDealer.Hit();
         if(health <= 0)
        {
            Die();
            
        }
    }
    public void Finger()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = Vector2.Lerp(currentPosition, touchPosition, Time.deltaTime * moveSpeed);
            rb.MovePosition(targetPosition);
        }


    }

    //    public void Finger(){
    //     //-- This is the code for mobile touchscreen movement.

    //    if (Input.touchCount > 0){
    //        Touch touch = Input.GetTouch(0);
    //        Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);

    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //            if(GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchPos)){
    //                deltaX = touchPos.x - transform.position.x;
    //                //deltaY = touchPos.y - transform.position.y;
    //            }
    //            break;
    //            case TouchPhase.Moved:
    //            if(col == Physics2D.OverlapPoint(touchPos))
    //            rb.MovePosition ( new Vector2 (touchPos.x - deltaX , rb.position.y)); //touchPos.y -deltaY --Convert to V3 and add after minus sum.
    //            break;
    //        }
    //    }
    //}

    void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if( shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }


    public void Fire()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
        ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(laserShotSFX,Camera.main.transform.position, laserShotSFXVolume);
    }

    /*IEnumerator updateAliveScore()
    {
        while(!playerdead)
        {
            
            yield return new WaitForSeconds(5);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);// if you switch these two score starts at scorevalue. remember code top to bottom
        }
    }
    */

    void Die()
    {
        if (health <= 0)
        playerdead = true;
        FindObjectOfType<LevelLoading>().LoadGameOver();
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position, deathSFXVolume);
        LevelLoading.FirstTime = false;
    }
    public int GetHealth()
    {
        return Mathf.Max(health, 0);
    }
}

