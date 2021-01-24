using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Silmpelhealthbar : MonoBehaviour
{
    public Slider healthbar;
    PlayerHealth playerhealth;

    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthbar.minValue = 0;
        healthbar.maxValue = playerhealth.maxhealth;
    }

    void Update()
    {
        healthbar.value = playerhealth.currenthealth;
    }
}
