using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheilds : MonoBehaviour
{
    public int maxsheilds;
    public int currentsheilds;

    public float sheildtimer;
    private float currentsheildtimer;

    public float boostTimer;
    private float currentboosttimer;

    private void Start()
    {
        currentsheilds = maxsheilds;
        currentsheildtimer = sheildtimer;
        currentboosttimer = boostTimer;
    }

    public void TakeSheildDamage(int damage)
    {
        currentsheilds -= damage;
        if (currentsheilds < 0)
        {
            damage -= currentsheilds;
            currentsheilds = 0;
            gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (currentsheilds < maxsheilds)
        {
            sheildtimer -= Time.deltaTime;
            if (sheildtimer < 0)
            {
                currentsheilds++;
                sheildtimer = currentsheildtimer;
            }
        }
        else if (currentsheilds > maxsheilds)
        {
            sheildtimer -= Time.deltaTime;
            if (sheildtimer < 0)
            {
                currentsheilds = currentsheilds/2;
                sheildtimer = currentsheildtimer;
            }
        }
        if (boostTimer < 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentsheilds = 200;
                boostTimer = currentboosttimer;
            }
        }
        else
        {
            boostTimer -= Time.deltaTime;
        }
    }

}
