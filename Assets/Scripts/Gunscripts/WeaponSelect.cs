using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("weapon1")) 
        {
            weapon.GetComponent<Lazerscript>().enabled = true;
            weapon.GetComponent<projectileshooter>().enabled = false;
        }
        if (Input.GetButtonDown("weapon2")) 
        {
            weapon.GetComponent<Lazerscript>().enabled = false;
            weapon.GetComponent<projectileshooter>().enabled = true;
        }
    }
}
