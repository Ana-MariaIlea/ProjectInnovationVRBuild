using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommand : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    private void Start()
    {
        //actions.Add("can you help me", Help);
        //actions.Add("give directions", Directions);
         actions.Add("main menu", MainMenu);
        //actions.Add("quit", Quit);
        //actions.Add("are you here", AreYouHere);
        // actions.Add("hello", AreYouHere);

        var quitGame = FindObjectOfType<QuitGame>();
        if (quitGame.keyPhrase != "") {
            actions.Add(quitGame.keyPhrase, quitGame.onSayQuit);
        }


        foreach (var ActivateObject in FindObjectsOfType<ActivateObjectQuest>())
        {

            if (ActivateObject.KeyPhrase != "") {
                actions.Add(ActivateObject.KeyPhrase, ActivateObject.onPhraseHeardAction);
            }

            try
            {

                
            }
            catch (Exception err)
            {
                Debug.LogWarning(err);
            }

        }

        //Debug.Log(actions.Count);
        //foreach (var key in actions.Keys)
        //{
        //    Debug.Log(key);
        //}
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        Debug.Log("voice start");
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speeech)
    {
        Debug.Log(speeech.text);
        // if (actions.ContainsKey(speeech.text))
        //{
        actions[speeech.text].Invoke();
        // }
    }

    private void Help()
    {
        Debug.Log("Help on the way");
    }
    private void MainMenu()
    {
        Debug.Log("Main menu is open");
    }
    private void Directions()
    {
        Debug.Log("Here are the directions");
    }

    private void Quit()
    {
        Debug.Log("Are you sure you want to quit?");
    }

    private void AreYouHere()
    {
        Debug.Log("I am here");
    }
}
