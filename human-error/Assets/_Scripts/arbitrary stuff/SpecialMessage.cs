using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecialMessage : MonoBehaviour
{
    public string userName = Environment.UserName;
    public string txt;
    public string txt2;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshPro>().text = userName;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = txt + userName + txt2;
    }
}
