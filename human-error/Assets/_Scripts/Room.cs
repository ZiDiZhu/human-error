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


    public void Awake()
    {
        //Debug.Log("vibe check");
    }

    public void UpdateIcon()
    {

        if (this.isUnlocked)
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
            
            completedIcon.SetActive(true);
            //update email
            mailText.text = this.newEmail;
            greenDot.SetActive(true);

        }else if (!isClear)
        {
            completedIcon.SetActive(false);
        }

        
    }
}

