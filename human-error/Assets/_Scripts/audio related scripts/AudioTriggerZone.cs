using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//starts playing bgm when enter the collider 
public class AudioTriggerZone : MonoBehaviour
{
    public AudioSource bgm;

    private void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bgm.Play();
        }
    }
}
