using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win_script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
