using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FighterMove : MonoBehaviour
{
    public bool Stop = false;
    public float VerticalSpeed;
    public float RotationSpeed;
    public float Speed;
    public float Maxdistance;
    public float Mindistance;
    public float ActiveDistance;
    public Rigidbody Self;
    public Transform Target;
    public Rigidbody Avoid;
    float orbitTime = 10.0f;
    float stopCheckTime = 0.0f;
    void Start()
    {
        Self = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Target);
        if (Vector3.Distance(transform.position, Target.position) < ActiveDistance)
        {
            Self.AddRelativeForce(0, 0, VerticalSpeed);
        }
        if (Vector3.Distance(transform.position, Target.position) < Maxdistance)
        {
            Circle();
        }
    }

    void Circle()
    {
        if (Vector3.Distance(transform.position, Target.position) < Mindistance)
        {
            Self.AddRelativeForce(0, 0, -VerticalSpeed);
        }
        if (Vector3.Distance(transform.position, Target.position) > Mindistance && Vector3.Distance(transform.position, Target.position) < Maxdistance && stopCheckTime <= 0)
        {
            Self.velocity = Vector2.zero;
            Self.angularVelocity = Vector3.zero;
            stopCheckTime = 10.0f;
        }
        else if (orbitTime >= 0)
        {
            transform.RotateAround(Target.transform.position, Vector3.up, 20 * Time.deltaTime);
            orbitTime -= Time.deltaTime;
        }
        if(orbitTime <= 0)
        {
            transform.RotateAround(Target.transform.position, -Vector3.up, 20 * Time.deltaTime);
            orbitTime -= Time.deltaTime;
        }
        if(orbitTime <= -10)
        {
            orbitTime = 10f;
        }
        stopCheckTime -= Time.deltaTime;
    }
}
