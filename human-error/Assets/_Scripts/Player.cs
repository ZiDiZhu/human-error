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
        //lock the player's movement while in a dialogue
        if (dialogueUI.isOpen)
        {
            playerMovement.enabled = false;
        }
        else
        {
            playerMovement.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            //?. == if interactable != null
            Interactable?.Interact(this);
        }
    }
}
