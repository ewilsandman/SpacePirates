using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Gun : MonoBehaviour
{
    public Transform Target;
    public Rigidbody Self;
    public int Damage;
    public int Range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var checkPlayer = Target.position - transform.position;
        if (Physics.Raycast(transform.position, checkPlayer, out hit))
        {
            if (hit.transform == Target)
            {
                if (Physics.Raycast(Self.position ,Self.transform.forward, out hit, Range))
                {
                    // Set the end position for our laser line 
                    //lazerLine.SetPosition(1, hit.point);

                    // Get a reference to a health script attached to the collider we hit
                   /* Shields health = hit.collider.GetComponent<Sheilds>();

                    if (health != null)
                    {
                        // Call the damage function of that script, passing in our gunDamage variable
                        health.TakeDamage(Damage);
                    }
                   */
                }
            }
        }

    }
   /* private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        pewNoise.Play();

        // Turn on our line renderer
        lazerLine.enabled = true;

        //Wait for 1 second
        yield return new WaitForSeconds(1);

        // Deactivate our line renderer after waiting
        lazerLine.enabled = false;
    }*/
}
