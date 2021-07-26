using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public bool menuisOpen;

    void Start()
    {
        CloseMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuisOpen)
            {
                CloseMenu();
            }else if (!menuisOpen)
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuisOpen = true;
        
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menuisOpen = false;
    }
}
