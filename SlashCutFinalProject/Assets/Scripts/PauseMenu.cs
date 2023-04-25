using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{
    
  
    public bool isPaused = false; // boolean flag to keep track of whether the game is paused or not

    [SerializeField] GameObject pauseMenuUI; // reference to the UI panel for the pause menu
    [SerializeField] GameObject pauseText; 

    [SerializeField] GameObject volumeMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if the Escape key is pressed
        {
            if (isPaused)
            {
                Resume(); // if the game is already paused, resume it
            }
            else
            {
                Pause(); // if the game is not paused, pause it
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // disable the pause menu UI panel
        pauseText.SetActive(false);
        volumeMenu.SetActive(false);
        Time.timeScale = 1f; // resume the game's time scale
        isPaused = false; // set the isPaused flag to false
    }

    void Pause()
    {
       
        pauseMenuUI.SetActive(true); // enable the pause menu UI panel
        pauseText.SetActive(true);
        Time.timeScale = 0f; // set the game's time scale to 0, effectively pausing it
        isPaused = true; // set the isPaused flag to true
    }

   


}
