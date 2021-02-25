using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    [SerializeField]
    private float firerate;

    [SerializeField]
    private bool fire;

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
        fire = Input.GetKey(KeyCode.Space);

        if(fire && Time.time >= nextlanch)
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
