using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSliderValue : MonoBehaviour
{
    public Slider mySlider;

    public float minValue;
    public float maxValue;
    public bool inRange;

    private DialogueChanger dChanger;

    private void Start()
    {
        dChanger = GetComponent<DialogueChanger>();
    }



    public void Clock()
    {
        CheckValue();
        if (!inRange && dChanger != null)
        {
            dChanger.ChangeDialogueObject();
        }
    }

    public void CheckValue()
    {
        if (minValue <= mySlider.value && mySlider.value <= maxValue)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
}
