using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Gun : MonoBehaviour
{
    private LineRenderer lazerLine;
    public Transform Target;
    public Transform Self;
    public int Damage;
    public int Range;
    // Start is called before the first frame update
    void Start()
    {
        lazerLine = GetComponent<LineRenderer>();
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
                    lazerLine.enabled = true;

                    lazerLine.SetPosition(0, Self.position);

                    // Set the end position for our laser line 
                    lazerLine.SetPosition(1, hit.point);

                    // Get a reference to a health script attached to the collider we hit
                    // Sheilds health = hit.collider.GetComponent<Sheilds>();


                    if (hit.collider.GetComponent<Sheilds>() != null)
                    {
                        hit.collider.GetComponent<Sheilds>().TakeSheildDamage(Damage);
                    }

                }
            }
        }
    }
}
