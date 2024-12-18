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
    private bool canJump = true;
    
    /// <summary>
    /// I made a whole new script for movement in the lidar space. I dont know why but i thought i might as well.
    /// </summary>
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //This handles movement. This movement system has sprinting and sneaking built in.
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
        if (Input.GetAxisRaw("Jump") > 0 && isOnGround && canJump)
        {
            canJump = false;
            rb.AddForce(player.transform.up * 75f);
            Timing.CallDelayed(0.75f, () => { canJump = true; });
        };

        #endregion
        //This is a very simple camera rotation system. It rotates the camera up and down but rotates
        //the player left and right so the rigidbody moves forwards in the right direction
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
