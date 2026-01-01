using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSession : MonoBehaviour
{
    public int score = 0;
    
    public int powerupCounter = 0;
    public int enemiesDestroyedCounter = 0;
    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        int numberofGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberofGameSessions > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void resetGame()
    {
        Destroy(gameObject);
    }
    
}
