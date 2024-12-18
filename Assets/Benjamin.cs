using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Benjamin : MonoBehaviour
{
    /// <summary>
    /// This is clearly the most complex script ever written and could not be integrated into something else
    /// </summary>
    public GameObject bill;
    #warning make sure to add nukes
    
    void Update()
    {
        transform.LookAt(bill.transform);
    }
}
