using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        if ("GameOverscean" == SceneManager.GetActiveScene().name)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if("victory" == SceneManager.GetActiveScene().name)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("Opening");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
