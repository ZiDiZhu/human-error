using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeInteractable : MonoBehaviour
{
    public GameObject thing;
    public GameObject interactIndicator;
    [SerializeField]private bool inRange;

    public PlayerMovement playermovement;
    public MouseLook mouseLook;

    private void Start()
    {
        thing.SetActive(false);
        interactIndicator.SetActive(false);
        inRange = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactIndicator.SetActive(true);
            inRange = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactIndicator.SetActive(false);
            inRange = false;
        }
    }

    private void Update()
    {
        if (inRange)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                playermovement.enabled = false;
                mouseLook.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                thing.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitInteraction();
            }
        }
    }

    public void ExitInteraction()
    {
        playermovement.enabled = true;
        mouseLook.enabled = true;
        thing.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
