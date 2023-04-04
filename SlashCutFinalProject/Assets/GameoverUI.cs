using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
 
  public GameObject gameOverMenu;
  private void OnEnable() 
  {
    HealthBarScipt.OnPlayerDeath += EnableGameOverMenu;
  }

   private void OnDisable() 
  {
    HealthBarScipt.OnPlayerDeath -= EnableGameOverMenu;
  }


  public void EnableGameOverMenu()
  {
    gameOverMenu.SetActive(true);
  }

  public void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }


  public void BackToMain()
  {
    SceneManager.LoadScene("SampleScene");
  }
}
