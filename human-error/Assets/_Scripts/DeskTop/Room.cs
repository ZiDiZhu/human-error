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

    public bool isPuzzleRoom = false; //some rules are different for puzzle rooms

    public string sceneName;

    public GameObject icon;

    public Texture lockedIcon;
    public Texture unlockedIcon;
    public GameObject completedIcon;

    public TMP_Text mailText;
    [TextArea(15, 20)]
    public string newEmail;
    public GameObject greenDot; //to notify that theres a new mail
    public bool notified; // avoid being called twice


    public void Awake()
    {
        //Debug.Log("vibe check");
    }

    //lol this was made when i didn't know what a case/switch was. Maybe change this to a switch statement later
    public void UpdateIcon()
    {

        if (this.isUnlocked)
        {
            icon.GetComponent<RawImage>().texture = unlockedIcon;
            if (!isClear)
            {
                icon.GetComponent<Button>().interactable = true;
            }
            
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
            if (!notified)
            {
                Notify();
                notified = true;
            }

        }
        else
        {
            if(completedIcon != null)
            {
                completedIcon.SetActive(false);
            }
            
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

        

    }
}

