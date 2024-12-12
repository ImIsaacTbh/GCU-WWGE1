using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIDARGun : MonoBehaviour
{
    public GameObject emitter, indicatorMark;
    public GameObject camera;
    public GameObject lights;
    private int wallMask = 1 << 10;
    private bool LightsToggle = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire3") != 0 && LightsToggle)
        {
            Debug.Log("SwitchingLights");
            LightsToggle = false;
            lights.SetActive(!lights.activeSelf);
            Timing.CallDelayed(0.5f, ()  => {LightsToggle = true; });
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            Physics.Raycast(emitter.transform.position, camera.transform.forward+(camera.transform.up*UnityEngine.Random.Range(-0.15f, 0.15f))+(camera.transform.right*UnityEngine.Random.Range(-0.15f, 0.15f)), out RaycastHit hitInfo, 20, wallMask);
            Instantiate(indicatorMark, hitInfo.point, new()).isStatic = true;
        }
    }
}
