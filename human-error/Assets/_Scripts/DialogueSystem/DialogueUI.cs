using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    public bool isOpen { get; set; }

    //[SerializeField] private DialogueObject testDialogue;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;


      private void Start()
      {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
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

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E));
        }


        //checks if there are any responses to show at the end of Dialogues
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses); 
        }
        else
        {
            CloseDialogueBox();
        }
      }

      private void CloseDialogueBox()
      {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text=string.Empty;
      }

}
