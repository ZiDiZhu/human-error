using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    //ok this is pretty dumb but i can't figure out how structs work in unity so 

    public bool isUnlocked;
    public bool isClear;

    public string sceneName;

    public Sprite lockedIcon;
    public Sprite unlockedIcon;
    public GameObject completedIcon;

    #region SINGLETON-NING
    private static Room _instance;

    public static Room Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        //destroy other copies but not other rooms
        if (_instance != null && _instance != this && _instance.sceneName == this.sceneName)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public void UpdateIcon()
    {
        if (isUnlocked)
        {
            this.GetComponent<Image>().sprite = unlockedIcon;
        }

        if (isClear)
        {
            completedIcon.SetActive(true);
        }
    }
}

