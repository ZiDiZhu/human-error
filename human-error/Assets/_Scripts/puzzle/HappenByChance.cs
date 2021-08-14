using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HappenByChance : MonoBehaviour
{
    // an event that happens by chance
    public UnityEvent regularEvent;
    public UnityEvent specialEvent;

    public float chance = 10f; //10/10

    public float generatedNum;

    public void TakeChance()
    {
        generatedNum = Random.Range(1, 10);
        
        if(generatedNum >= chance)
        {
            specialEvent.Invoke();
        }
        else
        {
            regularEvent.Invoke();
        }
    }

}
