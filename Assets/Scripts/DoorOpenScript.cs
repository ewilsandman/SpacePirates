using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public Transform player;
    public Animation anim;
    public float ActiveDistance;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {

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
    }
}
