using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTeleport : MonoBehaviour
{
    public GameObject destinationTile;
    public GameObject avatar;

    public Tilemap myMap;


    //public GameObject child; //black tile blocker

    public GameObject retryButton;

    public bool isDead = false;

    private void Start()
    {
        //TeleportToDestination();
    }

    private void Update()
    {
        if(destinationTile != null)
        {
            CheckIfCanTeleport();
        }
        else
        {
            Debug.Log("no destination");
        }
        
    }


    private void CheckIfCanTeleport()
    {
        Vector3Int gridPosition = myMap.WorldToCell(avatar.transform.position);

        if (!myMap.HasTile(gridPosition))
        {
            //do nothing
        }
        else
        {
            TeleportToDestination();
            destinationTile.GetComponent<TileTeleport>().isDead = true;
            this.gameObject.SetActive(false);
        }
    }

    private void TeleportToDestination()
    {
        if (!isDead)
        {
            Vector3Int goal = myMap.WorldToCell(destinationTile.transform.position);
            avatar.transform.position = myMap.GetCellCenterWorld(goal);
        }
        else
        {
            //check if next tile is available
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
