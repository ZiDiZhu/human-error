using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndUpdateRooms : MonoBehaviour
{
    public GameObject[] roomObject;

    public string theRoomName;
    public GameObject theRoom; //find by name

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

    public void FindByName()
    {
        roomObject = GameObject.FindGameObjectsWithTag("room");
        foreach (GameObject room in roomObject)
        {
            if (room.GetComponent<Room>().sceneName == theRoomName)
            {
                theRoom = room.gameObject;
            }
        }
    }

    public void SetRoomCleared()
    {
        FindByName();
        theRoom.GetComponent<Room>().isClear = true;
    }

    public void SetRoomUnlocked()
    {
        FindByName();
        theRoom.GetComponent<Room>().isUnlocked = true;
    }

}
