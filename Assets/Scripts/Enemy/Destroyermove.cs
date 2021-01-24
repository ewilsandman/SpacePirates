using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyermove : MonoBehaviour
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
    public Vector3 Lookat;
    public Rigidbody Avoid;
    private Quaternion targetRotation;
    void Start()
    {
        Self = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) < ActiveDistance && Close == false)
        {
            transform.LookAt(Target);
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
        if (Close == true)
        {
            Lookat = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
            targetRotation = Quaternion.LookRotation(Lookat, Vector3.up);

            transform.RotateAround(Target.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
            targetRotation = Quaternion.Slerp(targetRotation, Self.rotation, 1);
            transform.rotation = targetRotation;
        }
    }
}