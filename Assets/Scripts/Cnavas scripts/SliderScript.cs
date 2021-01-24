using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider sheildbar;
    Sheilds playersheilds;

    void Start()
    {
        playersheilds = GameObject.FindGameObjectWithTag("Player").GetComponent<Sheilds>();
        sheildbar.minValue = 0;
        sheildbar.maxValue = playersheilds.maxsheilds;
    }

    void Update()
    {
        sheildbar.value = playersheilds.currentsheilds;
    }
}
