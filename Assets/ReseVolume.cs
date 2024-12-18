using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReseVolume : MonoBehaviour
{
    //A reset volume so if the player falls or jumps off the map they get set to the default position
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            c.gameObject.transform.position = new Vector3(-0.3316973f, 2.727468f, -13.57937f);
            c.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
