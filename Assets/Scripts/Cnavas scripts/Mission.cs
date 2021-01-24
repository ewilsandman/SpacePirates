using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mission : MonoBehaviour
{
    public string instructions;
    public Text MissionDisplay;
    // Start is called before the first frame update
    void Start()
    {}

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
    }
}
