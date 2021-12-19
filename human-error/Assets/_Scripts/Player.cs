using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController cc;
    public PlayerMovement playerMovement;

    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI=> dialogueUI;


    public Interactable Interactable { get; set; }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //Debug.Log(Cursor.lockState);
        //lock the player's movement while in a dialogue
        if (dialogueUI.isOpen)
        {
            playerMovement.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!dialogueUI.isOpen)
        {
            playerMovement.enabled = true;

            
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                InteractionClick();
            }
            
        }

    }

    public void InteractionClick()
    {
        
        Interactable?.Interact(this);
    }
}
