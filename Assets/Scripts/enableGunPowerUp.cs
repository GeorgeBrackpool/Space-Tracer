using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableGunPowerUp : MonoBehaviour
{
    FingerMovement playerWeapon;
       [SerializeField] GameObject laserPrefab;

        float Xpadding = 1f;
        float shotCounter;
        [SerializeField]  float minTimeBetweenShots = 0.2f;
        [SerializeField]  float maxTimeBetweenShots = 0.3f;

        [SerializeField] float laserspeed = 25f;

        [SerializeField] public AudioClip laserShotSFX;
        [SerializeField][Range(0,1)]public  float laserShotSFXVolume; 
          

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

     public void CountDownAndShoot()
    {
        if (gameObject != null){

       
        shotCounter -= Time.deltaTime;
        if( shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
         }
    }
    public void Fire()
    {
        GameObject laser1 = Instantiate(laserPrefab,

                transform.position+new Vector3(Xpadding,0,0),

                Quaternion.identity) as GameObject;
          laser1.GetComponent<Rigidbody2D>().velocity = new Vector2(0,laserspeed);
            GameObject laser2 = Instantiate(laserPrefab,

                transform.position- new Vector3(Xpadding, 0, 0),

                Quaternion.identity) as GameObject;

           laser2.GetComponent<Rigidbody2D>().velocity =new Vector2(0,laserspeed);
           AudioSource.PlayClipAtPoint(laserShotSFX,Camera.main.transform.position, laserShotSFXVolume);

    }
}
