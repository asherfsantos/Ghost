using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour {

    //Made by Justin Acosta

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game");
    }

    public void Options()
    {
        Debug.Log("Opening Options");
    }

    public void MainMenu()
    {
        Debug.Log("Exiting to Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Exiting to Desktop");
    }
}
