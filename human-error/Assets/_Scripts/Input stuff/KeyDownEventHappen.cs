using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDownEventHappen : MonoBehaviour
{
    public KeyCode key;
    public UnityEvent myEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            myEvent.Invoke();
        }
    }
}
