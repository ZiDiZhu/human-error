using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    //SetActive switch

    public GameObject thing;
    public bool isOn;

    public bool offOnLoad = true;

    private void Start()
    {
        if (offOnLoad)
        {
            isOn = false;
            thing.SetActive(false);
        }
        
    }



    public void SwitchOnOff()
    {
        if (isOn)
        {
            thing.SetActive(false);
            isOn = false;
        }
        else
        {
            thing.SetActive(true);
            isOn = true;
        }
    }
}
