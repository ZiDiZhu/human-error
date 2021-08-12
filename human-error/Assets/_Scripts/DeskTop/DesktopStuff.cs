using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DesktopStuff : MonoBehaviour
{

    System.DateTime timeNow = System.DateTime.Now;

    public Text timeDisplay;

    private void Start()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        timeDisplay.text = timeNow.ToString();

    }


}
