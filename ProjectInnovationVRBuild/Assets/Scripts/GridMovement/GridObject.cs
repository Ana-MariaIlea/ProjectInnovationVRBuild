using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GridObject :MonoBehaviour, IGridCollidable
{
    [SerializeField]
    GameGrid gameGrid;

    [SerializeField]
    Vector2Int position;
    [SerializeField]
    Vector2Int direction;

    CellData cellData;



    public UnityEvent onCollision;

    void OnValidate() {

        //if(gameGrid != null)
        //{
        //    direction = new Vector2Int((int)transform.forward.x, (int)transform.forward.z);
        //    cellData = new CellData(this.gameObject, 1);
        //    gameGrid.PlaceGameObjectOnCell(cellData, position.x, position.y);
        //}
    }

    //void ()
    //{
    //    

    //}



    public void OnGridCollision(IGridCollidable other = null)
    {
        onCollision?.Invoke();
    }
}
