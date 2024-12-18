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
    
    void Update()
    {
        if (Input.GetAxis("Fire3") != 0 && LightsToggle)
        {
            //I had to find a way for people to see so added a light
            LightsToggle = false;
            lights.SetActive(!lights.activeSelf);
            Timing.CallDelayed(0.5f, ()  => {LightsToggle = true; });
        }
    }
    //I threw this in fixed update because then the output wasnt framerate dependant 
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            //The direction is random in a cone so that it has bullet spread sort of
            Physics.Raycast(emitter.transform.position, camera.transform.forward+(camera.transform.up*UnityEngine.Random.Range(-0.15f, 0.15f))+(camera.transform.right*UnityEngine.Random.Range(-0.15f, 0.15f)), out RaycastHit hitInfo, 20, wallMask);
            //Indicator mark (the coloured dots) doesnt have a script its done via shaders in /LIDAR/Particle.shadergraph
            Instantiate(indicatorMark, hitInfo.point, new()).isStatic = true;
        }
    }
}
