using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindByTagAndDelete : MonoBehaviour
{

    public GameObject thing;
    public string tagName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindAndDelete()
    {
        thing = GameObject.FindWithTag(tagName);

        if(thing != null)
        {
            thing.SetActive(false);
        }
        
    }
}
