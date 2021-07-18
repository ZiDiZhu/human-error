using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caption : MonoBehaviour
{
    public GameObject caption;

    private void Start()
    {
        caption.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            caption.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            caption.SetActive(false);
        }
    }
}
