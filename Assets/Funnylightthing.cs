using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Funnylightthing : MonoBehaviour
{
    //This is the quest for the ridge wallet
    void Update()
    {
        var sin = Mathf.Sin(Time.time);
        if (sin < 0) sin *= -1;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(5.18f, 6.04f, sin), transform.position.z);
        transform.rotation = Quaternion.Euler(0, Mathf.LerpAngle(0, 360, Time.time), 0);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            SceneManager.LoadScene("WinnerWinnerChickenDinner");
        }
    }
}
