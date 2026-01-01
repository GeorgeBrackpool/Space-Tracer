using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    GameSession gameSession;
 public static bool firstTime = true;
 public static bool FirstTime { get { return firstTime; } set { firstTime  = value; } }
   [SerializeField] float timeDelaySeconds = 2f;
  public void LoadStartMenu()
  {
      SceneManager.LoadScene(0);
  }

  public void LoadGame()
  {
      SceneManager.LoadScene("Game");
      if (!firstTime)
      FindObjectOfType<GameSession>().resetGame();
    
  }

  public void LoadGameOver()
  {
      StartCoroutine(GameOverDelay());
  }
  public void LoadAboutMenu()
  {
      SceneManager.LoadScene("About Menu");
  }
  public void LoadHowToMenu()
  {
      SceneManager.LoadScene("How To Menu");
  }
    public void LoadHowToMenuPage2()
  {
      SceneManager.LoadScene("How To Menu Page2");
  }
  public void LoadHowToMenuPage3()
  {
      SceneManager.LoadScene("How To Menu Page3");
  }
   public void LoadHowToMenuPage4()
  {
      SceneManager.LoadScene("How To Menu Page4");
  }
   public void LoadSettingsMenu()
  {
      SceneManager.LoadScene("Settings Menu");
  }
    private IEnumerator GameOverDelay()
    {
       
        yield return new WaitForSeconds(timeDelaySeconds);
        SceneManager.LoadScene("Game Over");
    }
  
}
