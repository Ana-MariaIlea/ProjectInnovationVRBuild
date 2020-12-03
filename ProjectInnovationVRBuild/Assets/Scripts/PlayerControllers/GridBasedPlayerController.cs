using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedPlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField]
    GameGrid gameGrid;

    [SerializeField]
    Vector2Int position;
    Vector2Int direction;

    CellData cellData;


    void Start() {
        direction = new Vector2Int((int)transform.forward.x, (int)transform.forward.z);
        cellData = new CellData(this.gameObject, 1);
        gameGrid.PlaceGameObjectOnCell(cellData, position.x, position.y);
    }

    public void MoveBackwards(float speed)
    {
        Vector2Int position = new Vector2Int(this.position.x, this.position.y);
        gameGrid.RemoveObjectFromCell(position.x, position.y);

        position = position - direction;
        if (gameGrid.PlaceGameObjectOnCell(cellData, position.x, position.y))
        {
            this.position = position;
        };
    }
    public void MoveForward(float speed)
    {
        Vector2Int position = new Vector2Int(this.position.x, this.position.y);
        gameGrid.RemoveObjectFromCell(position.x, position.y);

        position = position + direction;
        
        if (gameGrid.PlaceGameObjectOnCell(cellData, position.x, position.y)) {
            this.position = position;
        };
    }

    public void MoveLeft(float speed)
    {
       throw new System.NotImplementedException();
    }
    public void MoveRight(float speed)
    {
        throw new System.NotImplementedException();
    }
    public void TurnLeft(float amount = 90)
    {
        if (direction.x > 0)
        {
            direction.x = 0;
            direction.y = 1;
        }
        else if (direction.y < 0)
        {
            direction.x = 1;
            direction.y = 0;
        }
        else if (direction.x < 0)
        {
            direction.x = 0;
            direction.y = -1;
        }
        else if (direction.y > 0)
        {
            direction.x = -1;
            direction.y = 0;
        }

        transform.LookAt(transform.position + new Vector3(direction.x, 0, direction.y));
    }

    public void TurnRight(float amount = 90)
    {
        if (direction.x > 0)
        {
            direction.x = 0;
            direction.y = -1;
        }
        else if (direction.y < 0)
        {
            direction.x = -1;
            direction.y = 0;
        }
        else if (direction.x < 0)
        {
            direction.x = 0;
            direction.y = 1;
        }
        else if (direction.y > 0)
        {
            direction.x = 1;
            direction.y = 0;
        }

        transform.LookAt(transform.position + new Vector3(direction.x, 0, direction.y));
    }
}
