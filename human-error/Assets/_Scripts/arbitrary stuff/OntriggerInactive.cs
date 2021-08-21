using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OntriggerInactive : MonoBehaviour
{
    public GameObject thing;

    private void Start()
    {
        thing.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thing.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thing.SetActive(true);
        }
    }
}
