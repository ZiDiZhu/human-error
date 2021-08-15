using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommands : MonoBehaviour
{
    public bool cursorLocked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CursorOnOff();
        }
    }

    public void CursorOnOff()
    {
        if (!cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursorLocked = true;
        }
        else if (cursorLocked)
        {
            CursorOn();
        }
    }

    public void CursorOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
    }
}
