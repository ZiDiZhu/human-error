using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIndDesktop : MonoBehaviour
{
    public GameObject desktop;
    public bool isOn;
    // Start is called before the first frame update
    void Awake()
    {
        Hook();
        isOn = false;
        desktop.GetComponent<Canvas>().enabled = false;
    }

    public void Hook()
    {
        desktop = GameObject.FindWithTag("Desktop");
      
    }

    public void OnOffDeskTop()
    {
        if (isOn)
        {
            desktop.GetComponent<Canvas>().enabled = false;
            isOn = false;
        }
        else
        {
            desktop.GetComponent<Canvas>().enabled = true;
            isOn = true;
        }
    }
}
