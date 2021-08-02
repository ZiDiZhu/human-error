using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextStringText : MonoBehaviour
{
    public TMP_Text ondisplay;

    public string[] myText;
    public int currentTextNumber = 0;

    private void Start()
    {

    }

    public void NextString()
    {
        ondisplay.text = myText[currentTextNumber];
        currentTextNumber++;
        if(currentTextNumber >= myText.Length )
        {
            currentTextNumber = 0;
        }
    }
}
