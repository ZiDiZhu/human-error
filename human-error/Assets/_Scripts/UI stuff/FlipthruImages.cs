using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FlipthruImages : MonoBehaviour
{
    public Image myPage;
    public Sprite[] pages;
    public int currentPageNum;

    public int specialPageNum = 20;
    public UnityEvent specialEvent;


    private void Start()
    {
        myPage = GetComponent<Image>();
    }

    public void NextImage()
    {
        currentPageNum++;
        if(currentPageNum >= pages.Length)
        {
            currentPageNum = 0;
            
        }
        myPage.sprite = pages[currentPageNum];
        if (currentPageNum == specialPageNum)
        {
            specialEvent.Invoke();
        }
    }

    public void PreviousImage()
    {
        currentPageNum--;
        if (currentPageNum < 0)
        {
            currentPageNum = pages.Length-1;
        }
        myPage.sprite = pages[currentPageNum];
        if (currentPageNum == specialPageNum)
        {
            specialEvent.Invoke();
        }
    }
}
