using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPortal : MonoBehaviour
{
    public GameObject destination;
    public GameObject avatar;
    public GameObject child;

    public GameObject retryButton;

    public bool isDead;

    private void Start()
    {
        child = this.gameObject.transform.GetChild(0).gameObject;
        child.SetActive(false);
        //retryButton?.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (destination != null && !destination.GetComponent<ColorPortal>().isDead)
            {
                avatar.transform.position = destination.transform.position;
                child.SetActive(true);
                isDead = true;
                GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                Debug.Log("oh no u'r trapped");
                //retryButton?.SetActive(true); //why does ?. still gives error messages 
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
