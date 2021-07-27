using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockNext : MonoBehaviour
{
    //used to unlock next item once this is triggered i guess

    public GameObject[] nextToUnlock;
    private TypewriterEffect typewriterEffect;

    public string txt;
    public TMP_Text label;


    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        foreach (GameObject i in nextToUnlock)
        {
            i.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject i in nextToUnlock)
            {
                i.SetActive(true);
            }
            

            typewriterEffect.Run(txt, label);
        }
    }
}
