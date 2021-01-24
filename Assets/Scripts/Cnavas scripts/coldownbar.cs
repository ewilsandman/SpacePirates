using UnityEngine;
using UnityEngine.UI;

public class coldownbar : MonoBehaviour
{
    public Slider shootbar;
    projectileshooter playershoot;
    Lazerscript lazershoot;
    private bool gun;
    private float lazertimemax;
    private float guntimemax;

    void Start()
    {
        playershoot = GameObject.FindGameObjectWithTag("Gun").GetComponent<projectileshooter>();
        lazershoot = GameObject.FindGameObjectWithTag("Gun").GetComponent<Lazerscript>();

        shootbar.minValue = 0;
        lazertimemax = lazershoot.fireRate;
        guntimemax = playershoot.timeLeft;
        shootbar.maxValue = lazertimemax;
        gun = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("weapon1"))
        {
            shootbar.maxValue = lazertimemax;
            gun = false;
        }

        if (Input.GetButtonDown("weapon2"))
        {
            shootbar.maxValue = guntimemax;
            gun = true;
        }

        if (gun == false)
        {
            shootbar.value = lazershoot.timeLeft;
        }

        if (gun == true)
        {
            shootbar.value = playershoot.timeLeft;
        }
    }
}
