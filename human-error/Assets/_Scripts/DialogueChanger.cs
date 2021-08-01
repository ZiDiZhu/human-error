using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChanger : MonoBehaviour
{
    //changes the dialoguye object in the DialogueActivator on the object
    //will be used when certain conditions are met

    public DialogueObject newDialogueObject;
    [SerializeField] private DialogueActivator dActivator;

    private void Start()
    {
        dActivator = GetComponent<DialogueActivator>();
    }

    public void ChangeDialogueObject()
    {
        dActivator.dialogueObject = newDialogueObject;
    }


}
