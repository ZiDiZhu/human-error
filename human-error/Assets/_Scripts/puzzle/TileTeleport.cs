using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTeleport : MonoBehaviour
{
    /// <summary>
    ///  This code should be attached to an empty child to the tilemap that contains a single tile
    /// </summary>
    /// 

    public GameObject destinationTile;
    public GameObject avatar;

    public Tilemap myMap;

    public Tilemap exitTile;

    public Tilemap groundTilemap; //to block the road after the player was on it


    public AudioSource sfx_teleport;
    public AudioSource sfx_win;

    public bool isDead = false;

    public GameObject btn_nextlevel;
    public GameObject btn_retry;

    [SerializeField]Vector3Int gridPosition;

    private void Start()
    {
        //TeleportToDestination();
        myMap = this.transform.parent.GetComponent<Tilemap>();
        sfx_teleport = GetComponent<AudioSource>();
        if (btn_nextlevel)
        {
            btn_nextlevel.SetActive(false);
        }
        if (btn_retry)
        {
            btn_retry.SetActive(true);
        }

    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("A key or mouse click has been detected");
            if (destinationTile != null)
            {
                CheckIfCanTeleport();
            }
            else
            {
                Debug.Log("no destination");
            }
        }

        
        
    }


    private void CheckIfCanTeleport()
    {
        gridPosition = myMap.WorldToCell(avatar.transform.position);

        //if on exit tile
        if (exitTile.HasTile(exitTile.WorldToCell(gridPosition)))
        {
            Debug.Log("WINNNN");
            if(sfx_win != null)
            {
                sfx_win.Play();
            }
            if (btn_retry)
            {
                btn_retry.SetActive(false);
            }

            if (btn_nextlevel != null)
            {
                btn_nextlevel.SetActive(true);
            }
        }


        if (!myMap.HasTile(gridPosition))//not on tile
        {
            //do nothing
        }
        else//ontile
        {
            if (!isDead)
            {
                TeleportToDestination();
            }
            
        }
    }

    private void TeleportToDestination()
    {
        if (!destinationTile.GetComponent<TileTeleport>().isDead)
        {
            groundTilemap.SetTile(gridPosition, null);//disable road
            Vector3Int goal = myMap.WorldToCell(destinationTile.transform.position);
            avatar.transform.position = myMap.GetCellCenterWorld(goal);
            this.transform.parent.gameObject.GetComponent<TilemapRenderer>().enabled = false;
            destinationTile.GetComponent<TileTeleport>().isDead = true;
            sfx_teleport.Play();
            isDead = true;
            
        }
        else
        {
            
        }
    }

}
