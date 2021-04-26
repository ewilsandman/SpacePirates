using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public Transform player;
    public Animation anim;
    public float ActiveDistance;
    public GameObject[] Defenders;
    private int healthCheck = 0;
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Defenders.Length == 0)
        {
            anim.Play();

        }
    }

    // Update is called once per frame
    void Update() //Observera SCUFFED kod, däremot fungerar den.
    {
            foreach (GameObject Enemy in Defenders)
            {
                if (Enemy == null)
                {}
                else
                {
                healthCheck = healthCheck + 1;
                }
            }
            if (healthCheck > 0)
            {
            healthCheck = 0;
            }
            else if(open == false)
            {
            anim.Play();
            open = true;   
            }
    }

    /*
        RaycastHit hit;
        var rayDirection = player.position - transform.position;
        if (Vector3.Distance(transform.position, player.position) < ActiveDistance)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if (hit.transform == player)
                {
                    anim.Play();
                }
            }
        }
    }*/
}
