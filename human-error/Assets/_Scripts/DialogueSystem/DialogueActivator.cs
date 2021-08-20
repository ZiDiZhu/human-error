using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour, Interactable
{
    public DialogueObject dialogueObject; //to add dialogue object in the inspector 

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
        dialogueIndicator.SetActive(true);

    }

    public GameObject dialogueIndicator; //a ? that indicates there's a dialogue to be triggered
    public GameObject player;
    

    void Start()
    {
        if (dialogueIndicator != null)
        {
            dialogueIndicator.SetActive(false);
            
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Interact(Player player)
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                player.DialogueUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }

        player.DialogueUI.ShowDialogue(dialogueObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out Player player))
            {
                player.Interactable = this;
            }

            //sets up the ? indicator
            if(dialogueIndicator != null)
            {
                dialogueIndicator.SetActive(true);
            }
            


            //dialogueIndicator.GetComponent<TextAnimator>().rotationSpeed = 0.5f;
        }
    }

    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            if (dialogueIndicator != null)
            {
                dialogueIndicator.SetActive(false);
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out Player player))
            {
                if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
                {
                    player.Interactable = null;
                }
            }

            if (dialogueIndicator != null)
            {
                dialogueIndicator.SetActive(false);
            }
        }
    }
}
