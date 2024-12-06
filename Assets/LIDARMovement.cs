using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIDARMovement : MonoBehaviour
{
    private float hoz, vert;
    private float choz, cvert;
    public float walkSpeed;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        #region Movement
        hoz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        
        float sprintMultiplier = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;
        float sneakMultiplier = Input.GetKey(KeyCode.C) ? 0.75f : 1f;
        
        GetComponentInChildren<Rigidbody>().AddForce(transform.right*(vert*walkSpeed*sprintMultiplier*sneakMultiplier)*(Time.deltaTime*100));
        GetComponentInChildren<Rigidbody>().AddForce(transform.forward*(-hoz*walkSpeed*sprintMultiplier*sneakMultiplier)*Time.deltaTime*100);
        #endregion
        #region Camera

        choz = Input.GetAxisRaw("Mouse X");
        cvert = Input.GetAxisRaw("Mouse Y");

        transform.GetChild(0).Rotate(new Vector3(0, 0, choz*2.5f));
        transform.GetChild(0).Rotate(new Vector3(0, cvert*2.5f, 0));
        #endregion
    }
}
