using System;
using System.Collections.Generic;
using Cinemachine;
using MEC;
using UnityEngine;

public class Bill : MonoBehaviour
{
    public float walkSpeed;
    public bool stop;
    public float moveJump;
    public bool jump;
    private bool pauseToggle = true;
    public bool pauseMenu;
    public GameObject pauseOverlay;
    private void Start()
    {
        stop = true;
        Timing.RunCoroutine(CameraSweep());
    }
    //Changing priority with a transition will do the cool sweep so i wait for the scene to properly load then start the sweep
    //there is more to do with this is CullingMaskFixer.cs
    private IEnumerator<float> CameraSweep()
    {
        yield return Timing.WaitForSeconds(0.5f);
        GameObject.Find("SweepCam").GetComponent<CinemachineVirtualCamera>().Priority = -1;
        yield return Timing.WaitForSeconds(0.5f);
        stop = false;
    }

    /// <summary>
    /// I use the stop variable to make sure the player doesnt move while the transition (sweep) is running
    /// other than that its a very simple movement system
    /// </summary>
    void Update()
    {
        if (Input.GetAxis("Cancel") > 0 && pauseToggle)
        {
            pauseToggle = false;
            Timing.CallDelayed(0.5f, () => { pauseToggle = true; });
            pauseMenu = !pauseMenu;
            pauseOverlay.SetActive(pauseMenu);
            stop = pauseMenu;
            if (pauseMenu)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
        if (stop) return;
        GetComponent<Rigidbody>().AddForce(transform.up*-9.8f);
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        moveJump = Input.GetAxis("Jump");
        
        GetComponent<Rigidbody>().AddForce(transform.forward*(moveY*walkSpeed)*(Time.deltaTime*100));
        GetComponent<Rigidbody>().AddForce(transform.right*(moveX*walkSpeed)*(Time.deltaTime*100));
        if (moveJump != 0 && !jump)
        {
            jump = true;
            //Ground check raycast
            if (Physics.Raycast(transform.position, -transform.up, 5f, LayerMask.GetMask("Ground")))
            {
                GetComponent<Rigidbody>().AddForce(transform.up * 1500);
            }
            Timing.RunCoroutine(KeyCheck());
        }
    }

    //This makes sure that if you hold space nothing happens and you need to let go
    public IEnumerator<float> KeyCheck()
    {
        while (moveJump > 0)
        {
            yield return Timing.WaitForOneFrame;
        }
        jump = false;
    }
}
