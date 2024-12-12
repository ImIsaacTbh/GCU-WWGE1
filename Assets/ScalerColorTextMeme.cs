using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerColorTextMeme : MonoBehaviour
{
    public float baseScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = Mathf.Sin(Time.time) * baseScale;
        if (scale < 0) scale *= -1;
        transform.localScale = new Vector3(scale, scale, baseScale);
    }
}
