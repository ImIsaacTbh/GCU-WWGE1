using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIDARGun : MonoBehaviour
{
    public GameObject emitter, indicatorMark;
    public GameObject camera;
    private int wallMask = 1 << 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            Physics.Raycast(emitter.transform.position, camera.transform.forward+(camera.transform.up*UnityEngine.Random.Range(-0.1f, 0.1f))+(camera.transform.right*UnityEngine.Random.Range(-0.1f, 0.1f)), out RaycastHit hitInfo, 20, wallMask);
            Instantiate(indicatorMark, hitInfo.point, new()).isStatic = true;
        }
    }
}
