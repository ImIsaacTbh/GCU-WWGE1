using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tony : MonoBehaviour
{
    /// <summary>
    /// This entire script was for debug purposes and can be reactivated if needed later on
    /// </summary>
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
