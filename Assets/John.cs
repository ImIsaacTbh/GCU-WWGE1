using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bob;
    public float sens = 25f;
    private float rot = 0f;
    private bool stop = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Timing.CallDelayed(1.5f, () => { stop = false; });   
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;
        float mouseX = Input.GetAxis("Mouse X") * sens;
        float mouseY = Input.GetAxis("Mouse Y") * sens;
        
        rot -= mouseY;
        rot = Mathf.Clamp(rot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);
        Bob.transform.Rotate(Vector3.up * mouseX);
    }
}
