using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
    void Start()
    {
        if ("GameOverscean" == SceneManager.GetActiveScene().name)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if( "victory" == SceneManager.GetActiveScene().name)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("2_LVL");
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
