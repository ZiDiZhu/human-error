using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Hub World");
        }
    }

    public void ReturnToHubMenu()
    {
        SceneManager.LoadScene("HubWorld", LoadSceneMode.Additive);
    }
}
