using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour
{
    public float firerate;

    private bool fire;

    private float nextlanch;

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
        Debug.Log("Fire");
    }
}
