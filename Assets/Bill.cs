using System;
using System.Collections.Generic;
using Cinemachine;
using MEC;
using UnityEngine;

public class Bill : MonoBehaviour
{
    public float walkSpeed;
    public bool stop;
    public bool IsInverted = false;
    public float moveJump;
    public bool jump;
    private void Start()
    {
        stop = true;
        Timing.RunCoroutine(CameraSweep());
    }

    private IEnumerator<float> CameraSweep()
    {
        yield return Timing.WaitForSeconds(0.5f);
        GameObject.Find("SweepCam").GetComponent<CinemachineVirtualCamera>().Priority = -1;
        yield return Timing.WaitForSeconds(0.5f);
        stop = false;
    }

    void Update()
    {
        if (stop) return;
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
