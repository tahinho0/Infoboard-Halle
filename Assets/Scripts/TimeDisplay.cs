using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public GameObject theDisplay;

    public int hour, minutes, seconds;

    // Update is called once per frame
    private void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        theDisplay.GetComponent<Text>().text = "" + hour + ":" + minutes + ":" + seconds;
    }
}