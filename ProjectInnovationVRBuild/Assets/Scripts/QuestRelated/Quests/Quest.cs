using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Quest : MonoBehaviour, IQuest
{
    [SerializeField]
    string questIdentifier;

    public UnityEvent onQuestStart;
    public UnityEvent onQuestComplete;
    


    protected void MessageStart() {
        Debug.Log("Start quest " + questIdentifier);
    }
    protected void MessageEnd()
    {
        Debug.Log("End quest " + questIdentifier);
    }

    public void Awake()
    {
        onQuestStart.AddListener(MessageStart);
        onQuestComplete.AddListener(MessageEnd);
    }


    public virtual bool CheckCondition()
    {
        return false;
    }
}
