using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheilds : MonoBehaviour
{
    public int maxsheilds;
    public int currentsheilds;

    public float sheildtimer;
    private float currentsheildtimer;

    private void Start()
    {
        currentsheilds = maxsheilds;
        currentsheildtimer = sheildtimer;
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
    }
}
