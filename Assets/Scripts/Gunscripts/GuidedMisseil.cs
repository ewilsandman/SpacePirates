using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMisseil : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 20f;

    [SerializeField]
    private float accelerationTime = 7f;

    [SerializeField]
    private float missileSpeed = 20f;

    [SerializeField]
    private float turnRate = 50f;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float trackingDelay = 3f;

    private bool missileActive = false;

    private bool isAccelareting = false;

    private float accelerationActiveTime = 0f;

    private Quaternion guideRotation;

    private bool targetTracking = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ActivetMissile();
    }

    private void ActivetMissile()
    {
        missileActive = true;
        targetTracking = true;
        accelerationActiveTime = Time.time;
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

        Debug.Log("Missile speed" + missileSpeed);
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
        yield return new WaitForSeconds(Random.Range(trackingDelay, ))
    }
}
