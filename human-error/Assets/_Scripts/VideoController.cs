using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer VideoPlayer; 
    public string SceneName;

    public UnityEvent m_MyEvent;

    void Start()
    {
        VideoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        m_MyEvent.Invoke();
    }
}
