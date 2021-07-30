using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPortal : MonoBehaviour
{
    public GameObject destination;
    public GameObject avatar;


    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (destination != null)
            {
                avatar.transform.position = destination.transform.position;
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("oh no u'r trapped");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
