using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    public string instructions;
    public Text MissionDisplay;
    public float TimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        if ("3_LVL" == SceneManager.GetActiveScene().name)
        {
            TimeLeft = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if("1_LVL" == SceneManager.GetActiveScene().name)
        {
            instructions = "Find the glowing item";
             MissionDisplay.text = instructions.ToString();
        }
        else if ("2_LVL" == SceneManager.GetActiveScene().name)
        {
            instructions = "Kill the enemy on the other side";
            MissionDisplay.text = instructions.ToString();
        }
        else if ("3_LVL" == SceneManager.GetActiveScene().name)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft <= 0)
            {
                SceneManager.LoadScene("GameOverscean");
            }
            instructions = "Get out! " + TimeLeft.ToString();
            MissionDisplay.text = instructions.ToString();
        }
    }
}
