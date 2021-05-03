using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : MonoBehaviour
{
    public Rigidbody Self;
    public Transform Target;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var rayDirection = Target.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.transform == Target)
            {
                // Finds target rotation.
                var targetRotation = Quaternion.LookRotation(Target.transform.position - transform.position);

                // Smoothly rotates towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            }
        }
    }
}
