using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject Canvas;

    //public GameObject pauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Test if the Esc works
            //Debug.Log("Esc was pressed.");

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

    void Resume ()
    {
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        Canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
