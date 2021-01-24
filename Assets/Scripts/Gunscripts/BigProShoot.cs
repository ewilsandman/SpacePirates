using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class BigProShoot : MonoBehaviour
{
    GameObject prefab;
    public float timeLeft = 5.0f;
    AudioSource pewNoise;

    void Start()
    {
        pewNoise = GetComponent<AudioSource>();
        prefab = Resources.Load("bigprojectiel") as GameObject;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projectile = Instantiate(prefab);
                projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 5;
                timeLeft = 5.0f;
                pewNoise.Play(0);
            }
        }
    }
}
