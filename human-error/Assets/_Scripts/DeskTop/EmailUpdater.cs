using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailUpdater : MonoBehaviour
{
    public GameObject emailPanel;
    public GameObject mailText;
    public bool isOn;

    void Awake()
    {
        Hook();
        isOn = false;
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

    public void OnOffEmail()
    {
        Hook();

        if (isOn)
        {
            emailPanel.GetComponent<Canvas>().enabled = false;
            isOn = false;
        }
        else
        {
            emailPanel.GetComponent<Canvas>().enabled = true;
            isOn = true;
            mailText.GetComponent<TypeText>().Type();
        }
    }

}
