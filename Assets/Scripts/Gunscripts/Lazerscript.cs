using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazerscript : MonoBehaviour
{
    public float fireRate;
    AudioSource pewNoise;
    private LineRenderer lazerLine;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public int Damage = 1;
    public float timeLeft;
    public Camera mainCam;
    public float keepBeamTime;
    public Transform self;

    void Start()
    {
        lazerLine = GetComponent<LineRenderer>();
        pewNoise = GetComponent<AudioSource>();
        timeLeft = fireRate;
        lazerLine.positionCount = 2;
    }
    void Update()
    {

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeLeft = fireRate;
                // Start our ShotEffect coroutine to turn our laser line on and off
                StartCoroutine(ShotEffect());
                // Create a vector at the center of our camera's viewport
                Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                // Declare a raycast hit to store information about what our raycast has hit
                RaycastHit hit;
                Debug.Log(rayOrigin);

                // Set the start position for our visual effect for our laser to the position of gunEnd
                lazerLine.SetPosition(0, self.position);

                // Check if our raycast has hit anything
                if (Physics.Raycast(rayOrigin, mainCam.transform.forward, out hit, weaponRange))
                {
                    // Set the end position for our laser line 
                    lazerLine.SetPosition(1, hit.point);

                    // Get a reference to a health script attached to the collider we hit
                    EnemyHealth health = hit.collider.GetComponent<EnemyHealth>();

                    // If there was a health script attached
                    if (health != null)
                    {
                        // Call the damage function of that script, passing in our gunDamage variable
                        health.TakeDamage(Damage);
                    }

                    // Check if the object we hit has a rigidbody attached
                    if (hit.rigidbody != null)
                    {
                        // Add force to the rigidbody we hit, in the direction from which it was hit
                        hit.rigidbody.AddForce(-hit.normal * hitForce);
                    }
                }
                else
                {
                    // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                    lazerLine.SetPosition(1, rayOrigin + (mainCam.transform.forward * weaponRange));
                }
            }
        }
    }
        private IEnumerator ShotEffect()
        {
        // Play the shooting sound effect
        pewNoise.Play();

        // Turn on our line renderer
        lazerLine.enabled = true;

        //Wait for 1 second
        yield return new WaitForSeconds(1);

        // Deactivate our line renderer after waiting
        lazerLine.enabled = false;
    }
}