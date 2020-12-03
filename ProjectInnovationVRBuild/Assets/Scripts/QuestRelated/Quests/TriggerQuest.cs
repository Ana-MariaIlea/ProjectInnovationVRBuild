using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerQuest : Quest{


    bool playerIsInRoom = false;



  
    void OnTriggerEnter()
    {
        playerIsInRoom = true;
    }

    public override bool CheckCondition()
    {
        return playerIsInRoom;
    }

}
