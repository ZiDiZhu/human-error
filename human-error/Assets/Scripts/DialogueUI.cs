using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;


      private void Start()
      {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
      }

      public void ShowDialogue (DialogueObject dialogueObject)
      {
        dialogueBox.SetActive(true);
        StartCoroutine (StepThroughDialogue (dialogueObject));
      }

      private IEnumerator StepThroughDialogue (DialogueObject dialogueObject)
      {

        //Press SPACE to show next dialogue in the array, break if at the end of dialogues.
        for (int i=0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
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
        dialogueBox.SetActive(false);
        textLabel.text=string.Empty;
      }

}
