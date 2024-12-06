using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public GameObject[] weapons;
    private GameObject activeWeapon;
    
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            weapons[0].SetActive(!weapons[0].activeSelf);
            activeWeapon = weapons[0].activeSelf ? weapons[0] : null;
        }
    }
}
