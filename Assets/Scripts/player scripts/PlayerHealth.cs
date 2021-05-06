using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public int maxhealth;
    public int currenthealth;
    public GameObject Gameover;
    public GameObject UI;

    private void Start()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(int damage)
	{
        currenthealth -= damage;
		Debug.Log("Health = " + currenthealth.ToString());
	}

    private void Update()
    {
        if (currenthealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 00;
            Gameover.SetActive(true);
            UI.SetActive(false);
        }
    }
}
