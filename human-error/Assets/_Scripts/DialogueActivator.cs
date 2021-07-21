using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interactable
{
    [SerializeField] private DialogueObject dialogueObject;

    public GameObject dialogueIndicator; //indicate there's a dialogue to be triggered
    

    void Start()
    {
        dialogueIndicator.SetActive(false);
    }
    public void Interact(Player player)
    {
        if(TryGetComponent(out DialogueResponseEvents responseEvents))
        {
            player.DialogueUI.AddResponseEvents(responseEvents.Events);
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
