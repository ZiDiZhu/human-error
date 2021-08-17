using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room : MonoBehaviour
{
    //ok this is pretty dumb but i can't figure out how structs work in unity so 

    public bool isUnlocked;
    public bool isClear;

    public string sceneName;

    public GameObject icon;

    public Texture lockedIcon;
    public Texture unlockedIcon;
    public GameObject completedIcon;

    public TMP_Text mailText;
    public string newEmail;
    public GameObject greenDot; //to notify that theres a new mail
    public bool notified; // avoid being called twice


    public void Awake()
    {
        //Debug.Log("vibe check");
    }

    public void UpdateIcon()
    {

        if (this.isUnlocked && !isClear)
        {
            icon.GetComponent<RawImage>().texture = unlockedIcon;
            icon.GetComponent<Button>().interactable = true;
        }else if (!isUnlocked)
        {
            icon.GetComponent<RawImage>().texture = lockedIcon;
            icon.GetComponent<Button>().interactable = false;
        }

        if (isClear)
        {
            icon.GetComponent<Button>().interactable = false;
            if (completedIcon != null)
            {
                completedIcon.SetActive(true);
            }
        }
        else
        {
            if(completedIcon != null)
            {
                completedIcon.SetActive(false);
            }
            
        }

        if (!notified)
        {
            Notify();
        }
        
    }

    public void Notify()
    {

        if (isClear)
        {

            //update email
            mailText.text = this.newEmail;
            if (newEmail != null)
            {
                greenDot.SetActive(true);
            }

        }
        else if (!isClear)
        {
            //completedIcon.SetActive(false);
        }

        notified = true;

    }
}

