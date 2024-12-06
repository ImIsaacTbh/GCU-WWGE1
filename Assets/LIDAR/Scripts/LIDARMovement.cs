using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using UnityEngine.UI;

public class LIDARMovement : MonoBehaviour
{
    private float hoz, vert;
    private float choz, cvert;
    public float walkSpeed;
    public float sens;
    private float rot = 0f;
    public GameObject camera, player;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region Movement

        if (Input.GetKeyDown(KeyCode.C))
        {
            player.transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            player.transform.localScale = Vector3.one;
        }

        var rb = player.GetComponent<Rigidbody>();
        rb.AddForce(-player.transform.up * 15f);
        hoz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        
        float sprintMultiplier = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;
        float sneakMultiplier = Input.GetKey(KeyCode.C)  ? 0.25f : 1f;

        rb.AddForce(player.transform.forward*(vert*walkSpeed*sprintMultiplier*sneakMultiplier)*(Time.deltaTime*100));
        rb.AddForce(player.transform.right*(hoz*walkSpeed*sprintMultiplier*sneakMultiplier)*Time.deltaTime*100);

        int groundLayer = 1 << 9;
        bool isOnGround = Physics.Raycast(player.transform.position, -player.transform.up, 2.5f, groundLayer);
        if (Input.GetAxisRaw("Jump") > 0 && isOnGround)
        { rb.AddForce(player.transform.up * 75f); };

        #endregion
        #region Camera

        float mouseX = Input.GetAxis("Mouse X") * sens;
        float mouseY = Input.GetAxis("Mouse Y") * sens;

        rot -= mouseY;
        rot = Mathf.Clamp(rot, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(rot, 0f, 0f);
        player.transform.Rotate(Vector3.up * mouseX);
        #endregion
    }
}
