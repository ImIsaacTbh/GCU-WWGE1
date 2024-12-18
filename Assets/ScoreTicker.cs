using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTicker : MonoBehaviour
{
    //Score can be read off of the text box if needed but Time.time rounded should work unless it gets reset between scenes
    void Update()
    {
        GetComponent<TMP_Text>().text = Time.time.ToString("N0");
    }
}
