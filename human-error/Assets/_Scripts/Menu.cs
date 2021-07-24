using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public bool menuisOpen;
    UnityEvent m_MyEvent;

    void Start()
    {
        CloseMenu();
        if (m_MyEvent == null)
            m_MyEvent = new UnityEvent();

        m_MyEvent.AddListener(Ping);
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

    void Ping()
    {
        Debug.Log("Ping");
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        menuisOpen = true;
        
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menuisOpen = false;
    }
}
