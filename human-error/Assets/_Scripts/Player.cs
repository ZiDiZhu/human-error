using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController cc;

    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI=> dialogueUI;

    public Interactable Interactable { get; set; }

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (dialogueUI.isOpen) return;

        if (Input.GetMouseButton(0))
        {
            //?. == if interactable != null
            Interactable?.Interact(this);
        }
    }
}
