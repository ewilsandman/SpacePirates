﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMisseil : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float acceleration = 2f;

    [SerializeField]
    private float accelerationTime = 2f;

    [SerializeField]
    private float missileSpeed = 2f;

    [SerializeField]
    private float turnRate = 5f;

    [SerializeField]
    private float trackingDelay = 3f;

    [SerializeField]
    private int dameg;

    private bool missileActive = false;

    private bool isAccelareting = false;

    private float accelerationActiveTime = 0f;

    private Quaternion guideRotation;

    private bool targetTracking = false;

    [SerializeField]
    private Rigidbody rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        ActivetMissile();
    }

    private void ActivetMissile()
    {
        missileActive = true;
        accelerationActiveTime = Time.time;
        StartCoroutine(TargetTrackingDelay());
    }

    private void Update()
    {
        Run();
        GuidedMissile();
    }

    private void Run()
    {
        if (Since(accelerationActiveTime) > accelerationTime)
            isAccelareting = false;
        else
            isAccelareting = true;

        if (!missileActive) return;

        if (isAccelareting)
            missileSpeed += acceleration * Time.time;
        
        rb.velocity = transform.forward * missileSpeed;

        if (targetTracking)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, guideRotation, turnRate * Time.deltaTime);
    }

    private float Since(float since)
    {
        return Time.time - since;
    }

    private void GuidedMissile()
    {
        if (target == null) return;

        if(targetTracking)
        {
            Vector3 relativePosition = target.position - transform.position;
            guideRotation = Quaternion.LookRotation(relativePosition, transform.up);
        }

        Debug.Log("Guiding");
    }

    IEnumerator TargetTrackingDelay()
    {
        yield return new WaitForSeconds(Random.Range(trackingDelay, trackingDelay + 3f));
        targetTracking = true;
        Debug.Log("targetaccuerd");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Sheilds>())
            other.gameObject.GetComponent<Sheilds>().TakeSheildDamage(dameg);
        else if (other.gameObject.GetComponent<EnemyHealth>())
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(dameg);
        }
        Destroy(gameObject, 0.1f);
    }
}
