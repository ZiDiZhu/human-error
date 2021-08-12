using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class TimeTimer : MonoBehaviour
{
    public int hour = System.DateTime.Now.Hour;
    public int minutes = System.DateTime.Now.Minute;
    public int seconds = System.DateTime.Now.Second;
    public Text timeDisplay;

    public bool timeIsUp = false;
    public UnityEvent timeupEvent;

    public Slider minuteModSlider;

    //set by me, to create a "destination" time point
    public int hourAdd;
    public int minutesAdd;
    public int SecondsAdd;

    //for cheating
    public int hourMod;
    public int minutesMod;


    //time when events can start
    public int newHour;
    public int newMinutes;
    public int newSeconds;
    public Text newTimeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTime();

        //prevent timeIsUp when a timer hasnt been set
        newHour = 23;
        newMinutes = 59;
    }

    private void Update()
    {
        UpdateTime();
        if (!timeIsUp)
        {
            CheckIfTimeUp();
        }
    }

    public void UpdateTime()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        if(minutes + minutesMod > 60)
        {
            hourMod ++;
            minutes = 0;
            minutesMod = 0;
        }

        timeDisplay.text = (hour + hourMod) + ":" + (minutes + minutesMod) + ":" + seconds;
    }

    public void TimeCheat()
    {
        minutesMod = Mathf.RoundToInt(minuteModSlider.value);
    }

    public void SetTimer()
    {
        newHour = System.DateTime.Now.Hour + hourAdd;
        newMinutes = System.DateTime.Now.Minute + minutesAdd;
        newSeconds = System.DateTime.Now.Second + SecondsAdd;
        if(newTimeDisplay != null)
        {
            newTimeDisplay.text = newHour + ":" + newMinutes + ":00";
        }
        
    }

    //uhh it like checks if the time "now" is past the new time that was set by me. if it is, then allow the event to happen
    public void CheckIfTimeUp()
    {
        if (hour + hourMod < newHour || (hour + hourMod >= 23 && newHour == 0))
        {
            timeIsUp = false;
        }
        else if(hour +hourMod == newHour)
        {
            if (minutes + minutesMod >= newMinutes)
            {
                timeIsUp = true;
            }
            else
            {
                timeIsUp = false;
            }
        }else if (hour + hourMod > newHour)
        {
            timeIsUp = true;
        }

        if (timeIsUp)
        {
            TriggerTimeupEvent();
        }
    }

    public void TriggerTimeupEvent()
    {
        timeupEvent.Invoke();
    }
}
