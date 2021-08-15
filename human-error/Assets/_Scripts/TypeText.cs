using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeText : MonoBehaviour
{
    public string txt;
    public TMP_Text label;
    private TypewriterEffect typewriterEffect;

    // Start is called before the first frame update
    void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        txt = label.text;
    }

    public void Type()
    {
        txt = label.text;
        typewriterEffect.Run(txt, label);
    }
}
