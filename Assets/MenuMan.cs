using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleStartButton()
    {
        SceneManager.LoadScene("BullshitLoadingScreen");
    }

    public void HandleOptionsButton()
    {
        
    }
}