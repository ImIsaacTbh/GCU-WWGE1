using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIDARMusicTimer : MonoBehaviour
{
    //i didnt want the start of the song
    void Start()
    {
        GetComponent<AudioSource>().time = 105f;
    }
}
