using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class CloudOnceServices : MonoBehaviour
{
  public static CloudOnceServices instance;

     private void Awake() 
     {
        TestSingleton();
    }
  private void TestSingleton(){
      if(instance != null) {Destroy(gameObject);return; }
      instance = this;
      DontDestroyOnLoad(gameObject);
  }
  public void SubmitScoreToLeaderboard(int score){
      Leaderboards.highScore.SubmitScore(score);
  }
  public void Award10kScore(){
    if (Achievements.score10k.IsUnlocked){return;}
    Achievements.score10k.Unlock();
  }
  public void Award35kScore(){
    if (Achievements.score35k.IsUnlocked){return;}
    Achievements.score35k.Unlock();
  }
  public void Award50kScore(){
    if (Achievements.score50k.IsUnlocked){return;}
    Achievements.score50k.Unlock();
  }
  public void Award100kScore(){
    if (Achievements.score100k.IsUnlocked){return;}
    Achievements.score100k.Unlock();
  }
   public void Award300kScore(){
    if (Achievements.score300k.IsUnlocked){return;}
    Achievements.score300k.Unlock();
  }
  public void Award50EnemyKills(){
    if (Achievements.destroy50enemies.IsUnlocked){return;}
    Achievements.destroy50enemies.Unlock();
  }
  public void Award150EnemyKills(){
    if (Achievements.destroy150enemies.IsUnlocked){return;}
    Achievements.destroy150enemies.Unlock();
  }
  public void Award300EnemyKills(){
    if (Achievements.destroy300enemies.IsUnlocked){return;}
    Achievements.destroy300enemies.Unlock();
  }
  public void Award25PowerUp(){
    if (Achievements.collect25powerup.IsUnlocked){return;}
    Achievements.collect25powerup.Unlock();
  }
  public void Award50PowerUp(){
    if (Achievements.collect50powerup.IsUnlocked){return;}
    Achievements.collect50powerup.Unlock();
  }
}
