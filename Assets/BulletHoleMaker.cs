using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletHoleMaker : MonoBehaviour
{
    public GameObject bulletPrefab;
    void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit data, 1f);
        if(data.collider != null)
        {
            var b = Instantiate(bulletPrefab, data.point+(data.transform.forward*0.025f), Quaternion.LookRotation(data.normal));
            Destroy(this.gameObject);
        }
    }
}
