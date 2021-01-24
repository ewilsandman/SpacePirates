using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour 
{
	public int maxhealth;
    public int currenthealth;

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
            SceneManager.LoadScene("GameOverscean");
        }
    }
}
