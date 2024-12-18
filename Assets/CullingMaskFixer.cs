using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingMaskFixer : MonoBehaviour
{
    void Start()
    {
        //i change the culling mask of the main camera to hide the player as the gta zoom sort of animation finishes so that the camera doesn't go inside the model visibly
        Timing.CallDelayed(1.5f, () =>
        {
            Camera.main.cullingMask ^= 1<<3;
        });
    }
}
