using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{
    private void Start()
    {
    }
    float timeLeft = 0.01f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
