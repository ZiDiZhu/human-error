using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplayer : MonoBehaviour
{

    public KeyCode key;
    public Color normalColor;
    public Color pressedColor;
    [SerializeField] private Image square;


    private void Start()
    {
        square = GetComponent<Image>();
    }
    private void Update()
    {
        if (Input.GetKey(key))
        {
            square.color = pressedColor;
        }
        else
        {
            square.color = normalColor;
        }
    }
}
