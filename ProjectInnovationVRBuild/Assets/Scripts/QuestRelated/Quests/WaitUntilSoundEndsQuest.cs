using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilSoundEndsQuest : Quest
{
    [SerializeField]
    AudioSequence audioToWait;

    void Awake()
    {
        base.Awake();
    }


    private void Start()
    {
       
    }

    public override bool CheckCondition()
    {
        return audioToWait.GetComponent<AudioSequence>().SequenceEnded;
    }
}
