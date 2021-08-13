using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnLoad : MonoBehaviour
{
    //general purpose start function
    public float waitSeconds;

    public UnityEvent startEvent;
    void Start()
    {
        StartCoroutine(Countdown());
        
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(waitSeconds);
        startEvent.Invoke();
    }
}
