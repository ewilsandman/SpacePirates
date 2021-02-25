using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int dameg;

    float timeLeft = 20.0f;
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity * -1);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Sheilds>())
            other.gameObject.GetComponent<Sheilds>().TakeSheildDamage(dameg);
        else if(other.gameObject.GetComponent<EnemyHealth>())
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(dameg);
        }
        Destroy(gameObject, 0.1f);
    }
}
