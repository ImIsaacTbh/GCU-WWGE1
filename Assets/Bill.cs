using UnityEngine;

public class Bill : MonoBehaviour
{
    public float walkSpeed;

    public bool IsInverted = false;
    
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        
        GetComponent<Rigidbody>().AddForce(transform.forward*(moveY*walkSpeed));
        GetComponent<Rigidbody>().AddForce(transform.right*(moveX*walkSpeed));
        
    }
}
