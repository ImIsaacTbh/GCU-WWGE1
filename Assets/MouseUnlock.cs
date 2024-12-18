using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUnlock : MonoBehaviour
{
    //Just a drop in script for unlocking the mouse
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
