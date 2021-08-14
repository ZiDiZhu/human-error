using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public bool menuisOpen;

    public GameObject player;
    public GameObject playerCamera;

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

        //make the player not able to rotate camera when menu is open
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerCamera = player.transform.Find("Main Camera").gameObject;

            playerCamera.GetComponent<MouseLook>().canRotate = false;
            player.GetComponent<PlayerMovement>().canMove = false;
        }
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        menuisOpen = false;
        Cursor.visible = false;

        if (player != null)
        {
            playerCamera.GetComponent<MouseLook>().canRotate = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }
    }
}
