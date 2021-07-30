using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour
{
    public bool quickExit = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && quickExit)
        {
            SceneManager.LoadScene("Hub World");
        }
    }

    public void ReturnToHubMenu()
    {
        SceneManager.LoadScene("Hub World");
    }
}
