using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) 
            {
                Resume();
            }

            else
            {
                PauseMenu();
            }
        }
    }

    public void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Timeout.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        PauseMenuUI.SetActive(true);
        Timeout.timeScale = 0f;
        GameIsPaused = true;
    }

    public LoadMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame ()
    {
        Debug.Log("Exiting Game");
        Applicaton.Exit();
    }
}
