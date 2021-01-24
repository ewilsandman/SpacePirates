using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SttingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVloym(float volym)
    {
        audioMixer.SetFloat("volym", volym);
    }

    public void SetQualety(int qualetyindex)
    {
        QualitySettings.SetQualityLevel(qualetyindex);
    }
}
