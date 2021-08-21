using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gravitySlider : MonoBehaviour
{
    public Slider gSlider;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        changeGravity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeGravity()
    {
        playerMovement.gravity = gSlider.value *-1;
        playerMovement.jumpHeight = gSlider.value*-1 +13.8f;
    }
}
