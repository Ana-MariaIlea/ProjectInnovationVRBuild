using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLine : MonoBehaviour
{
    [SerializeField]
    public List<Quest> questList;


    int activQuest = 0;

    bool isFinished = false;
    private void Awake()
    {
        ActivateQuest(activQuest);
    }

    private void ActivateNextQuest() {
        if (questList ==null || questList.Count <= 0) {
            return;
        }
        if (activQuest < questList.Count - 1)
        {
            activQuest++;
            questList[activQuest].onQuestStart?.Invoke();
        }
        else
        {
            isFinished = true;
            Debug.Log("quest list Completed");
        }
    }

    private void ActivateQuest(int index)
    {
        if (questList == null || questList.Count <= 0)
        {
            return;
        }
        if (index <= questList.Count - 1)
        {
            questList[index].onQuestStart?.Invoke();
        }
    }


    private void Update()
    {
        if(!isFinished)
            CheckQuestCondition();
    }

    private void CheckQuestCondition() {
        if (questList == null || questList.Count <= 0)
        {
            return;
        }

        if (questList[activQuest].CheckCondition())
        {
            questList[activQuest].onQuestComplete?.Invoke();
            ActivateNextQuest();
        }
    }
}
