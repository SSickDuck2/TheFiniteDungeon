using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause = true;
    //public GameObject TransitionContainer;
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = false;
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = true;
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = true;
        Debug.Log("RestartGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ReturnToMainMenu()
    {
        Debug.Log("ReturnToMainMenu");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = true;
        SceneManager.LoadScene(0);
    }
}
