﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    GameObject fekd;
    public int maxhealth;
    public int currenthealth = 0;
    public Transform player;
    AudioSource boomNoise;

    private void Start()
    {
        fekd = Resources.Load("scuffed_cannon_head") as GameObject;
        currenthealth = maxhealth;
    }
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        Debug.Log("EnemyHealth = " + currenthealth.ToString());
    }
    private void Update()
    {
        if (currenthealth <= 0)
        {
            GameObject borkd = Instantiate(fekd) as GameObject;
            borkd.transform.position = transform.position;
            borkd.transform.LookAt(player);
            Destroy(gameObject);
        }
    }
}
