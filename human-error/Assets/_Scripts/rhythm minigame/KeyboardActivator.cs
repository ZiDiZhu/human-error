using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardActivator : MonoBehaviour
{

    public GameObject keyboard;


    private void Start()
    {
        keyboard.SetActive(false);
    }
    public void OpenKeyboard()
    {
        keyboard.SetActive(true);
    }

    public void CloseKeyboard()
    {
        keyboard.SetActive(false);
    }
}
