using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPredict : MonoBehaviour
{
    public GameObject target;
    public GameObject shooter;
    Rigidbody TargetRb;
    Rigidbody ShootRb;
	GameObject prefab;
    public float shotSpeed;
    // Start is called before the first frame update
    void Start()
    {
		prefab = Resources.Load("TargetOrb") as GameObject;
	}   
    // Update is called once per frame
    void Update()
    {
        TargetRb = target.GetComponent<Rigidbody>();
        ShootRb = shooter.GetComponent<Rigidbody>();
        // === variables you need ===
        //how fast our shots move
        //objects

        // === derived variables ===
        //positions
        Vector3 shooterPosition = shooter.transform.position;
        Vector3 targetPosition = target.transform.position;
        //velocities
        Vector3 shooterVelocity = ShootRb.velocity;
        Vector3 targetVelocity = TargetRb.velocity;

        //calculate intercept
        Vector3 interceptPoint = FirstOrderIntercept
        (
            shooterPosition,
            shooterVelocity,
            shotSpeed,
            targetPosition,
            targetVelocity
        );
		GameObject Orb = Instantiate(prefab) as GameObject;
		Orb.transform.position = interceptPoint;
		Debug.Log(interceptPoint);
		//now use whatever method to launch the projectile at the intercept point
	}
	//first-order intercept using absolute target position
	public static Vector3 FirstOrderIntercept
	(
		Vector3 shooterPosition,
		Vector3 shooterVelocity,
		float shotSpeed,
		Vector3 targetPosition,
		Vector3 targetVelocity
	)
	{
		Vector3 targetRelativePosition = targetPosition - shooterPosition;
		Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
		float t = FirstOrderInterceptTime
		(
			shotSpeed,
			targetRelativePosition,
			targetRelativeVelocity
		);
		return targetPosition + t * (targetRelativeVelocity);
	}
	//first-order intercept using relative target position
	public static float FirstOrderInterceptTime
	(
		float shotSpeed,
		Vector3 targetRelativePosition,
		Vector3 targetRelativeVelocity
	)
	{
		float velocitySquared = targetRelativeVelocity.sqrMagnitude;
		if (velocitySquared < 0.001f)
			return 0f;

		float a = velocitySquared - shotSpeed * shotSpeed;

		//handle similar velocities
		if (Mathf.Abs(a) < 0.001f)
		{
			float t = -targetRelativePosition.sqrMagnitude /
			(
				2f * Vector3.Dot
				(
					targetRelativeVelocity,
					targetRelativePosition
				)
			);
			return Mathf.Max(t, 0f); //don't shoot back in time
		}

		float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
		float c = targetRelativePosition.sqrMagnitude;
		float determinant = b * b - 4f * a * c;

		if (determinant > 0f)
		{ //determinant > 0; two intercept paths (most common)
			float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
					t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
			if (t1 > 0f)
			{
				if (t2 > 0f)
					return Mathf.Min(t1, t2); //both are positive
				else
					return t1; //only t1 is positive
			}
			else
				return Mathf.Max(t2, 0f); //don't shoot back in time
		}
		else if (determinant < 0f) //determinant < 0; no intercept path
			return 0f;
		else //determinant = 0; one intercept path, pretty much never happens
			return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
	}
}
