using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;
    [SerializeField] private ResponseEvent[] responseEvents;

    private List<GameObject> tempResponseButtons = new List<GameObject>();

    public GameObject player;
    public GameObject playerCamera;

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }

    public void AddResponseEvent(ResponseEvent[] responseEvents)
    {
        this.responseEvents = responseEvents;
    }

    public void ShowResponses (Response[] responses)
    {
        float responseBoxHeight = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerCamera = player.transform.Find("Main Camera").gameObject;

            playerCamera.GetComponent<MouseLook>().canRotate = false;
            player.GetComponent<PlayerMovement>().canMove = false;
        }

        for (int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;

            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;

            //turns response into button
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response,responseIndex));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }


        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);

    }

    //when a response is clicked
    private void OnPickedResponse(Response response, int responseIndex)
    {

        Debug.Log("Picked Response");

        //close the response box
        responseBox.gameObject.SetActive(false);

        //lock the cursor
        Cursor.lockState = CursorLockMode.Locked;

        if (player != null)
        {
            playerCamera.GetComponent<MouseLook>().canRotate = true;
            player.GetComponent<PlayerMovement>().canMove = true;
        }

        //destroy the response buttons
        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }

        tempResponseButtons.Clear();

        if (responseEvents != null && responseIndex <= responseEvents.Length)
        {
            responseEvents[responseIndex].OnPickedResponse?.Invoke();
        }

        responseEvents = null;


        if (response.DialogueObject)
        {
            Debug.Log("warning:response dialogue");
            //dialogueUI.CloseDialogueBox();
            //dialogueUI.ShowDialogue(response.DialogueObject);
        }
        else
        {
            Debug.Log("no response dialogue");

            dialogueUI.CloseDialogueBox();

            dialogueUI.canClose = true;
        }
        
    }
}
