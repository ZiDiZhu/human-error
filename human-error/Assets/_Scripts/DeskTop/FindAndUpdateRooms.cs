using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndUpdateRooms : MonoBehaviour
{
    public GameObject[] roomObject;

    private void Awake()
    {

    }

    public void FindAndUpdateRoom()
    {
        roomObject = GameObject.FindGameObjectsWithTag("room");

        foreach(GameObject room in roomObject)
        {
            room.GetComponent<Room>().UpdateIcon();
        }

        roomObject = null;
        roomObject = GameObject.FindGameObjectsWithTag("room");

    }
}
