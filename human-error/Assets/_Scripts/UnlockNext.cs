using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNext : MonoBehaviour
{
    //used to unlock next item once this is triggered i guess

    public GameObject nextToUnlock;

    private void Start()
    {
        nextToUnlock.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        nextToUnlock.SetActive(true);
    }
}
