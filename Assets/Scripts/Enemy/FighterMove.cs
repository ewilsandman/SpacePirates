using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FighterMove : MonoBehaviour
{
    public bool Stop = false;
    public bool Close = false;
    public float VerticalSpeed;
    public float RotationSpeed;
    public float Speed;
    public float CircleDistance;
    public float ActiveDistance;
    public Rigidbody Self;
    public Transform Target;
    public Rigidbody Avoid;
    float orbitTime = 10.0f;
    void Start()
    {
        Self = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Target);
        // Avoid = FindObjectOfType.GetComponent<Rigidbody>;
        if (Vector3.Distance(transform.position, Target.position) < ActiveDistance && Close == false)
        {
            Self.AddRelativeForce(0, 0, VerticalSpeed);
        }
        
        if (Vector3.Distance(transform.position, Target.position) < CircleDistance)
        {

            Close = true;
            Circle();
        }
            //if (Vector3.Distance(transform.position , ))
            {
            //Dodge();
        }
        Circle();
    }
    void Dodge()
    {

    }
    void Circle()
    {
        if (Stop == false && Close == true)
        {
            Self.velocity = Vector2.zero; Self.angularVelocity = Vector3.zero;
            Stop = true;
        }
        else if (Close == true)
        {
            transform.RotateAround(Target.transform.position, Vector3.up, 20 * Time.deltaTime);
            orbitTime -= Time.deltaTime;

        }
        if(orbitTime <= 0)
        {
            Stop = false;
            transform.RotateAround(Target.transform.position, Vector3.down, 20 * Time.deltaTime);
        }
    }
}
