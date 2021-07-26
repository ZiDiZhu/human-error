using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour, Interactable
{
    [SerializeField] private DialogueObject dialogueObject; //to add dialogue object in the inspector 

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject; 
    }

    public GameObject dialogueIndicator; //a ? that indicates there's a dialogue to be triggered
    

    void Start()
    {
        dialogueIndicator.SetActive(false); // don't show the ? indicator
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
            dialogueIndicator.SetActive(true);
            dialogueIndicator.GetComponent<TextAnimator>().rotationSpeed = 0.5f;
        }
    }

    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            dialogueIndicator.SetActive(false);

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

            //dialogueIndicator.SetActive(false);
            dialogueIndicator.GetComponent<TextAnimator>().rotationSpeed = 0f;
        }
    }
}
