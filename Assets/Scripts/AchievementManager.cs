using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    GameSession gameSession;
    FingerMovement fingerMovement;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        fingerMovement = FindObjectOfType<FingerMovement>();
        
    }
    private void Awake() {
       
    }
    // Update is called once per frame
    void Update()
    {
        AwardAchievement();
    }
    public void AwardAchievement()
    {
        //Achievements check 5000 over due to Big boss 5.
       if (gameSession.score >= 10000 && gameSession.score < 15550 || gameSession.score >= 10000 && gameSession.score < 10550){
            
            CloudOnceServices.instance.Award10kScore();
            
        }
        if (gameSession.score >= 35000 && gameSession.score < 40550 || gameSession.score >= 35000 && gameSession.score < 35550){
            
            CloudOnceServices.instance.Award35kScore();
        }
        if (gameSession.score >= 50000 && gameSession.score < 55550 || gameSession.score >= 50000 && gameSession.score < 50550){
            
            CloudOnceServices.instance.Award50kScore();
        }
        if (gameSession.score >= 100000 && gameSession.score < 105550 || gameSession.score >= 100000 && gameSession.score < 100550){
            
            CloudOnceServices.instance.Award100kScore();
        }
        if (gameSession.score >= 300000 && gameSession.score < 305550 || gameSession.score >= 300000 && gameSession.score < 300550){
            
            CloudOnceServices.instance.Award100kScore();
        }
        if (gameSession.powerupCounter == 25){
            CloudOnceServices.instance.Award25PowerUp();
            
        }
        if (gameSession.powerupCounter == 50){
            CloudOnceServices.instance.Award50PowerUp();
        }
        if (gameSession.enemiesDestroyedCounter == 50){
            CloudOnceServices.instance.Award50EnemyKills();
            
        }
        if (gameSession.enemiesDestroyedCounter == 150){
            CloudOnceServices.instance.Award150EnemyKills();
        }
        if (gameSession.enemiesDestroyedCounter == 300){
            CloudOnceServices.instance.Award300EnemyKills();
        }
   }
 
}
