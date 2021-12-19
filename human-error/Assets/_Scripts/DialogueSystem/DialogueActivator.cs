using UnityEngine;
using UnityEngine.UI;

public class DialogueActivator : MonoBehaviour, Interactable
{
    public DialogueObject dialogueObject; //to add dialogue object in the inspector 

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
        dialogueIndicator.SetActive(true);
        //hotfix for the bug where the dialoguebox closes after a response has been selected.
        //It doesn't really fix anything lol but locks the player movemnet until another input
        /*
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerCamera = player.transform.Find("Main Camera").gameObject;

            playerCamera.GetComponent<MouseLook>().canRotate = false;
            player.GetComponent<PlayerMovement>().canMove = false;
        }
        */


        //failed fix attemp:

        //player.GetComponent<Player>().DialogueUI.CloseDialogueBox();
        //Interact(player.GetComponent<Player>());

        //this should fix it!
        var canclose = player.GetComponent<Player>().DialogueUI.canClose;
        if (canclose ==true)
        {
            player.GetComponent<Player>().DialogueUI.continuedDialogue = dialogueObject;
            player.GetComponent<Player>().DialogueUI.canClose = false;//disable closing dialogue
        }
        //player.GetComponent<Player>().Interactable = this;

        Debug.Log("UpdatedDialogueObject");
    }

    public GameObject dialogueIndicator; //a ? that indicates there's a dialogue to be triggered
    public GameObject player;
    public GameObject playerCamera;


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
        Debug.Log("interact");

        player.DialogueUI.ShowDialogue(dialogueObject);
    }

    public void ReponseFix(Player player)
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                player.DialogueUI.AddResponseEvents(responseEvents.Events);
                break;

            }
        }
        Debug.Log("responseFix");

    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.TryGetComponent(out Player player))
            {
                Debug.Log("Player in range");
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
