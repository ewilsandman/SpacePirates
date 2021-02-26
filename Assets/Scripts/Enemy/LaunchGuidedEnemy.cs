using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGuidedEnemy : MonoBehaviour
{
    [SerializeField]
    private float firerate;

    [SerializeField]
    private float nextlanch;

    [SerializeField]
    private GuidedMisseil missile;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform launchSpot;

    private void Update()
    {
        if (Time.time >= nextlanch)
        {
            nextlanch = Time.time + firerate;
            FireMissile();
        }
    }

    private void FireMissile()
    {
        GuidedMisseil newMisseil = Instantiate(missile, launchSpot.position, launchSpot.rotation);
        newMisseil.target = target;
        Debug.Log("Fire");
    }
}
