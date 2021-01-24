using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class projectileshooter : MonoBehaviour
{
    GameObject prefab;
    public float timeLeft;
    AudioSource pewNoise;
    private float timeHolder;

    void Start()
    {
        timeHolder = timeLeft;
        pewNoise = GetComponent<AudioSource>();
        prefab = Resources.Load("projectile") as GameObject;
    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projectile = Instantiate(prefab);
                projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 10;
                timeLeft = timeHolder;
                pewNoise.Play(0);
            }
        }
    }
}
