using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public string keyPhrase;
    public Action onSayQuit;


    private void Awake()
    {
        onSayQuit += quitAction;
    }

    void quitAction() {
        StopApplication();
    
    }


    public void StopApplication() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
