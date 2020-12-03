using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerActions
{
    void MoveForward(float speed=0);
    void MoveLeft(float speed=0);
    void MoveRight(float speed=0);

    void MoveBackwards(float speed=0);

    void TurnLeft(float amount = 90);
    void TurnRight(float amount = 90);
}
