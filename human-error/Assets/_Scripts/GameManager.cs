using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Room[] room;

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (GameManager._instance == null)
        {
            var go = new GameObject("Toolbox");
            DontDestroyOnLoad(go);
            GameManager._instance = go.AddComponent<GameManager>();
        }
        return GameManager._instance;
    }

}
