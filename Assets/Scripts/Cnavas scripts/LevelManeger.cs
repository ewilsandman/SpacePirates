using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
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
