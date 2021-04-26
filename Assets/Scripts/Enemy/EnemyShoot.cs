using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class EnemyShoot : MonoBehaviour
{
    GameObject prefab;
    public float fireCooldown;
    private float timeBetweenShots = 0;
    public Transform player;
    public bool smallGun;
    AudioSource pewNoise;
    public float ActiveDistance;
    public bool barrel;

    void Start()
    {
        pewNoise = GetComponent<AudioSource>();
        if (smallGun == true)
            prefab = Resources.Load("projectile") as GameObject;
        if (smallGun == false)
            prefab = Resources.Load("bigprojectiel") as GameObject;
    }

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
                    timeBetweenShots = Time.deltaTime + timeBetweenShots;
                    if (timeBetweenShots > fireCooldown)
                    {
                        pewNoise.Play(0);
                        GameObject projectile = Instantiate(prefab) as GameObject;
                        projectile.transform.position = transform.position + transform.forward * 2;
                        Rigidbody rbp = projectile.GetComponent<Rigidbody>();
                        rbp.velocity = transform.forward * 250;
                        timeBetweenShots = 0;
                    }
                    Rigidbody rb = GetComponent<Rigidbody>();
                    if (barrel == false)
                    {
                        float distanceToPlane = Vector3.Dot(transform.up, player.position - transform.position);
                        Vector3 pointOnPlane = player.position - (transform.up * distanceToPlane);

                        transform.LookAt(pointOnPlane, transform.up);
                    }
                    else if (barrel == true)
                    {
                        transform.LookAt(player);
                    }
                }
                else
                {

                }
            }
        }
    }
}
