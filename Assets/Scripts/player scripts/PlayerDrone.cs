using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrone : MonoBehaviour
{
    public float VerticalSpeed;
    public float RotationSpeed;
    public float Speed;
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
        Circle();
        void Circle()
        {
            {
                targetRotation = Quaternion.LookRotation(Lookat, Vector3.right);

                transform.RotateAround(Target.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);

                transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, Time.deltaTime * 2.0f);
            }
        }
    }
}