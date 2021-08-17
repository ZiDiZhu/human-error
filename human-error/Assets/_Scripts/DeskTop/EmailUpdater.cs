using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailUpdater : MonoBehaviour
{
    public GameObject emailPanel;
    public GameObject mailText;
    public bool isOn;
    public bool startedTyping;

    void Awake()
    {
        Hook();
        isOn = false;
        startedTyping = false;
        emailPanel.GetComponent<Canvas>().enabled = false;
    }

    private void Start()
    {
        
    }

    public void Hook()
    {
        emailPanel = GameObject.FindWithTag("Mail");
        mailText = GameObject.FindWithTag("MailText");
    }

    public void CheckifON()
    {
        if(emailPanel.GetComponent<Canvas>().enabled == true)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
    }

    public void OnOffEmail()
    {
        Hook();
        CheckifON();
        if (isOn)
        {
            emailPanel.GetComponent<Canvas>().enabled = false;
            isOn = false;
        }
        else 
        {
            emailPanel.GetComponent<Canvas>().enabled = true;
            isOn = true;
            if (!startedTyping)
            {
                mailText.GetComponent<TypeText>().Type();
            }

            startedTyping = true;
        }
    }

}
