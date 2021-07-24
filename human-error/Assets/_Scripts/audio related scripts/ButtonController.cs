using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private RawImage rawImage;

    public AudioSource sound;

    public bool semitone;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();

        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            rawImage.color = Color.red;
            sound.Play();
        }

        if (Input.GetKeyUp(keyToPress))
        {
            if(this.semitone)
                rawImage.color = Color.black;
            else
                rawImage.color = Color.white;

            sound.Stop();
        }
    }
}
