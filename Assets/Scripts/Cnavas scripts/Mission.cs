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
    public bool TimeTrial;
    private string newinstruction;
    // Start is called before the first frame update
    void Start()
    {}
    // Update is called once per frame
    void Update()
    {
        if(TimeTrial == true)
        {
            TimeLeft -= Time.deltaTime;
            if (TimeLeft <= 0)
            {
                SceneManager.LoadScene("GameOverscean");
            }
            newinstruction = instructions + UnityEngine.Mathf.Round(TimeLeft);
            MissionDisplay.text = newinstruction.ToString();
        }
        else
        {
            MissionDisplay.text = instructions.ToString();
        }
    }
}
