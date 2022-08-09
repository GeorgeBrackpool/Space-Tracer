using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }
  
}
