using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour, Interactable
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    public GameObject dialogueIndicator; //indicate there's a dialogue to be triggered
    

    void Start()
    {
        dialogueIndicator.SetActive(false);
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
