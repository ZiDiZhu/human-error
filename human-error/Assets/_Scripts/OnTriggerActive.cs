using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerActive : MonoBehaviour
{
    //sets a thing active when in trigger collider

    public GameObject thing;

    private void Start()
    {
        thing.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            thing.SetActive(true);
            Cursor.lockState = CursorLockMode.None; //if the thing is meant to be interactive
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thing.SetActive(false);
        }
    }
}
