using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletHoleMaker : MonoBehaviour
{
    //This is for the bullet impact decal
    public GameObject bulletPrefab;
    void Update()
    {
        //I raycast in a random cone again for better accuracy when it hits an angled surface
        Physics.Raycast(transform.position, transform.forward+(transform.up*UnityEngine.Random.Range(-0.15f, 0.15f))+(transform.right*UnityEngine.Random.Range(-0.15f, 0.15f)), out RaycastHit data, 1);
        if(data.collider != null)
        {
            var point = new Vector3(data.point.normalized.x*data.point.magnitude+(data.normal.normalized.x*0.5f), data.point.normalized.y*data.point.magnitude+(data.normal.normalized.y*0.5f), data.point.normalized.z*data.point.magnitude+(data.normal.normalized.z*0.5f));
            
            var b = Instantiate(bulletPrefab, point, Quaternion.LookRotation(-data.normal));
            Destroy(this.gameObject);
        }
    }
}
