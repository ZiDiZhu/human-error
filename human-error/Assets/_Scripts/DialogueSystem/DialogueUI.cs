using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool isOpen { get; set; }


    public GameObject player;
    public GameObject playerCamera;
    //[SerializeField] private DialogueObject testDialogue;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    public DialogueObject continuedDialogue;

    public bool canClose = false; //fix the issue of exiting the dialogue


    private void Start()
      {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        player = GameObject.FindGameObjectWithTag("Player");
        CloseDialogueBox();

        //ShowDialogue(testDialogue);
      }

      public void ShowDialogue (DialogueObject dialogueObject)
      {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine (StepThroughDialogue (dialogueObject));
      }
      
      public void AddResponseEvents(ResponseEvent[] responseEvents)
      {
        responseHandler.AddResponseEvent(responseEvents);
      }

      private IEnumerator StepThroughDialogue (DialogueObject dialogueObject)
      {

        //LEFT CLICK to show next dialogue in the array, break if at the end of dialogues.
        for (int i=0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            //wait for the player to click left or E to continue to the next dialogue in the array
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E));
        }

        //checks if there are any responses (in inspector of dialogueobject)

        //***disabling rn to test
        if (dialogueObject.HasResponses)
        {
            Debug.Log("showing responses");

            responseHandler.ShowResponses(dialogueObject.Responses);

        }
        else
        {
            Debug.Log("no response");

            CloseDialogueBox();
        }
    }

      public void CloseDialogueBox()
      {

        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text=string.Empty;
        if (player != null)
        {
            playerCamera = player.transform.Find("Main Camera").gameObject;

            playerCamera.GetComponent<MouseLook>().canRotate = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }

        if (!canClose)
        {
            if (continuedDialogue)
            {
                //ShowDialogue(continuedDialogue); //this doesnt add events
                player.GetComponent<Player>().Interactable.Interact(player.GetComponent<Player>());
            }
            //canClose = true;
        }
      }

}

//player.GetComponent<Player>().Interactable.Interact(player.GetComponent<Player>());