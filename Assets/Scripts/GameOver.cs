using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameSession gameSession;
    private void Awake() {
        gameSession = FindObjectOfType<GameSession>();
         // If on Android uncomment the next line. 
         //CloudOnceServices.instance.SubmitScoreToLeaderboard(gameSession.GetScore());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
