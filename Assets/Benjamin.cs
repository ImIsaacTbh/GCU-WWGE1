using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Benjamin : MonoBehaviour
{
    public GameObject bill;
    public GameObject canOpener;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    #warning make sure that make nukes
    
    // Update is called once per frame
    void Update()
    {
        // Thread distance = new Thread(() =>
        // {
        //     while (true)
        //     {
        //         if (Vector3.Distance(this.transform.position, bill.transform.position) < 50)
        //         {
        //             canOpener.GetComponent<Jim>().Fire();
        //         }
        //         Thread.Sleep(1000);
        //     }
        // });
        //distance.Start();
        //Vector3 dir = new Vector3(this.transform.position.x, 0f, this.transform.position.z) - new Vector3(bill.transform.position.x, 0f, bill.transform.position.z);
        //transform.rotation = Quaternion.Euler(this.transform.position - dir);
        transform.LookAt(bill.transform);
    }
}
