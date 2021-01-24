using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth = 0;

    private void Start()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        Debug.Log("EnemyHealth = " + currenthealth.ToString());
    }

    private void Update()
    {
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("victory");
        }
    }
}
