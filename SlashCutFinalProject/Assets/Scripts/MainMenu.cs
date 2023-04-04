using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class MainMenu : MonoBehaviour
{
     public GameObject options;

     void start() 
    { 
    
    options.SetActive(false);

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene");
        Time.timeScale = 1f; // resume the game's time scale
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
