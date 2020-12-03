using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridCollidable 
{
    void OnGridCollision(IGridCollidable other);
}
