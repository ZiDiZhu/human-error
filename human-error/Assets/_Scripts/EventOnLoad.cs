using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnLoad : MonoBehaviour
{
    //general purpose start function

    public UnityEvent startEvent;
    void Start()
    {
        startEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
