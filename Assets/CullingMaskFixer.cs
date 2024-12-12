using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingMaskFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //i change the culling mask of the main camera to hide the player as the gta zoom sort of animation finishes (using |=, &= and ^= bitwise operators)
        Timing.CallDelayed(1.5f, () =>
        {
            Camera.main.cullingMask ^= 1<<3;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
