using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseBotton;

    [SerializeField] private GameObject pauseMenu;

    private bool _gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        _gamePaused = true;

        Time.timeScale = 0.0f;

        pauseMenu.SetActive(false);

        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        _gamePaused = false;

        Time.timeScale = 1f;

        pauseMenu.SetActive(true);

        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        _gamePaused = false;

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}