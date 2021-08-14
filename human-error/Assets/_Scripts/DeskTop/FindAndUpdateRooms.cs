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
        Debug.Log("finding");

        roomObject = GameObject.FindGameObjectsWithTag("room");

        foreach(GameObject room in roomObject)
        {
            room.GetComponent<Room>().UpdateIcon();
        }

    }
}
