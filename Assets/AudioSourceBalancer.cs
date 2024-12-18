using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceBalancer : MonoBehaviour
{
    //drop in script that makes sure everything is playing at the correct volume
    void Start()
    {
        var Settings = DataStorage.Settings;
        foreach (AudioSource a in GetComponents<AudioSource>())
        {
            a.volume = Settings.Volume;
        }
    }
}
