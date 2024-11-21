using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using TMPro;
using UnityEngine;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class AbsolutLoading : MonoBehaviour
{
    private float TimeSpentLoading = 0f;

    private TextMeshProUGUI textbox;
    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TextMeshProUGUI>();
        Timing.RunCoroutine(dotdotdot());
    }

    IEnumerator<float> dotdotdot()
    {
        while (TimeSpentLoading < 9f)
        {
            textbox.text += '.';
            yield return Timing.WaitForSeconds(0.2f);
        }
    }
    
    void Update()
    {
        Debug.Log(TimeSpentLoading);
        TimeSpentLoading += Time.deltaTime;
        if (TimeSpentLoading > 9f) SceneManager.LoadScene("MainTest");
    }
}
