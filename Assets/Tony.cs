using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tony : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     Reset();
        // }
    }

    void Reset()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().rotation = new();
        transform.position = Vector3.zero;

    }
}