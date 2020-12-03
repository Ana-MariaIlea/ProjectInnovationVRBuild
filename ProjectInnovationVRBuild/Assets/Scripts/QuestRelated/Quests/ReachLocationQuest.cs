using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachLocationQuest : Quest
{
    [SerializeField]
    GameObject user;

    bool reachedTarget = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == user) {
            reachedTarget = true;
        }   
    }

    public override bool CheckCondition()
    {
        return reachedTarget;
    }
}
