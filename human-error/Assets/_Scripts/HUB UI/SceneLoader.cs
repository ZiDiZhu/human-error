using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string toLoad;
    private Button btn;

    private void Start()
    {
        if (btn!= null)
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(LoadScene);
        }
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(toLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
