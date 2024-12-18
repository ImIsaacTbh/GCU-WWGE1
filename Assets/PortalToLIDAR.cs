using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToLIDAR : MonoBehaviour
{
    public bool Reverse;

    //this is the portal
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("CheckingCollision");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Sending To LIDAR");
            SceneManager.LoadScene("LIDAR");
        }
        if(Reverse && other.gameObject.tag == "Player")
        {
            Debug.Log("Returning To Sandbox");
            SceneManager.LoadScene("BullshitLoadingScreen");
        } 
    }
}
