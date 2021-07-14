using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this code was taken from Semag Games' tutorial

public class TypewriterEffect : MonoBehaviour
{

    //note: SerializeField is used when you want to see a private  variable in the editor
    [SerializeField] private float typeSpeed = 50f;

    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
      return StartCoroutine(TypeText(textToType,textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {

      textLabel.text = string.Empty;

      //yield return new WaitForSeconds(1);

      float t = 0;
      int charIndex = 0;

      while (charIndex < textToType.Length)
      {
          t += Time.deltaTime * typeSpeed;
          charIndex = Mathf.FloorToInt(t);
          charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

          textLabel.text = textToType.Substring(0,charIndex);

          yield return null;
      }

      textLabel.text = textToType;
    }
}
