using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanKiller : MonoBehaviour
{
    //Kills you when the can touches you
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LolYouDied");
        }
        else if(other.gameObject.tag != "Barrel")
        {
            Destroy(gameObject);
        }
    }
}
