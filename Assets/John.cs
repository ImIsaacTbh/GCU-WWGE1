using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John : MonoBehaviour
{
    /// <summary>
    /// Quite simple but the stop variable is again for the sweep
    /// </summary>

    public GameObject mainPlayer;
    public GameObject Bob;
    public float sens = 25f;
    private float rot = 0f;
    private bool stop = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Timing.CallDelayed(1.5f, () => { stop = false; });   
    }
    
    void Update()
    {
        if (stop || mainPlayer.GetComponent<Bill>().stop) return;
        float mouseX = Input.GetAxis("Mouse X") * sens;
        float mouseY = Input.GetAxis("Mouse Y") * sens;
        
        rot -= mouseY;
        rot = Mathf.Clamp(rot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);
        Bob.transform.Rotate(Vector3.up * mouseX);
    }
}
