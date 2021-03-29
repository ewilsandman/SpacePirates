using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTarget : MonoBehaviour
{
    public int maxhealth;
    public int currenthealth = 0;
    public Animation TopDoor;
    public Animation BotDoor;

    private void Start()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        //Debug.Log("EnemyHealth = " + currenthealth.ToString());
    }

    private void Update()
    {
        if (currenthealth < maxhealth)
        {
            TopDoor.Play();
            BotDoor.Play();
            Destroy(gameObject);
        }
    }
}
