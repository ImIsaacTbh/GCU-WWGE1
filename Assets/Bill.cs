using System;
using System.Collections.Generic;
using MEC;
using UnityEngine;

public class Bill : MonoBehaviour
{
    public float walkSpeed;

    public bool IsInverted = false;
    public float moveJump;
    public bool jump;
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        moveJump = Input.GetAxis("Jump");
        
        GetComponent<Rigidbody>().AddForce(transform.forward*(moveY*walkSpeed)*(Time.deltaTime*100));
        GetComponent<Rigidbody>().AddForce(transform.right*(moveX*walkSpeed)*(Time.deltaTime*100));
        if (moveJump != 0 && !jump)
        {
            jump = true;
            GetComponent<Rigidbody>().AddForce(transform.up * 750);
            Timing.RunCoroutine(KeyCheck());
        }
    }

    public IEnumerator<float> KeyCheck()
    {
        while (moveJump > 0)
        {
            yield return Timing.WaitForOneFrame;
        }

        jump = false;
    }
}
