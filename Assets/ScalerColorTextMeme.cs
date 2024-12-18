using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerColorTextMeme : MonoBehaviour
{
    public float baseScale;
    
    //This is the text at the mirror
    void Update()
    {
        float scale = Mathf.Sin(Time.time) * baseScale;
        if (scale < 0) scale *= -1;
        transform.localScale = new Vector3(scale, scale, baseScale);
    }
}
