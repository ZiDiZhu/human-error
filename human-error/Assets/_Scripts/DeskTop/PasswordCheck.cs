using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PasswordCheck : MonoBehaviour
{
    public InputField inputField;
    public string password;
    public UnityEvent myEvent;
    public void checkPass()
    {
        if(inputField.text == password)
        {
            myEvent.Invoke();
        }
    }

}
