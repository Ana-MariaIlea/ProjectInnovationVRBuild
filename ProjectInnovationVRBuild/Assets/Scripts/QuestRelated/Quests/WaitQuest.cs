using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitQuest : Quest
{
    [SerializeField]
    float timer;

    public override bool CheckCondition()
    {
        timer -= Time.deltaTime;
        return timer<=0;
    }
}
