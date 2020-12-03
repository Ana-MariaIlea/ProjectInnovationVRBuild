using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField]
    int gridSizeX=10;
    [SerializeField]
    int gridSizeZ=10;
    
    
    [SerializeField]
    int gridElementSize = 10;

    [SerializeField]
    CellData[,] grid;



    private void OnValidate()
    {
        grid = new CellData[gridSizeX, gridSizeZ];
        for (int i = 0; i < gridSizeX; i++) {
            for (int j = 0; j < gridSizeZ; j++) {
                grid[i, j] = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < gridSizeZ; x++) {
            Vector3 startPosition = new Vector3(x * gridElementSize, 0, 0) + transform.position;
            Vector3 endPosition = new Vector3(x * gridElementSize, 0, gridSizeZ * gridElementSize) + transform.position;
            Gizmos.DrawLine(startPosition, endPosition);
        }
        for (int z = 0; z < gridSizeZ; z++)
        {
            Vector3 startPosition = new Vector3(0, 0, z*gridElementSize) + transform.position;
            Vector3 endPosition = new Vector3(gridSizeX * gridElementSize, 0, z * gridElementSize) + transform.position;
            Gizmos.DrawLine(startPosition, endPosition);
        }
    }


    public Vector3 GetCellCenter(int x, int z) {
        if (x < 0 || x >= gridSizeX) { throw new System.IndexOutOfRangeException(); }
        if (z < 0 || z >= gridSizeZ) { throw new System.IndexOutOfRangeException(); }

        float xPos = transform.position.x + x * gridElementSize + gridElementSize / 2;
        float zPos = transform.position.z + z * gridElementSize + gridElementSize / 2;

        return new Vector3(xPos, 0, zPos);
    }

    public int IsCellEmpty(int x, int z){
        if (x < 0 || x >= gridSizeX) return -1;
        if (z < 0 || z >= gridSizeZ) return -1;

        if (grid[x, z] == null) return 0;
        return grid[x, z].value;
    }

    public bool PlaceGameObjectOnCell(CellData objectToPlace, int x, int z) {
        if (IsCellEmpty(x, z) == -1) {
            return false;
        }
        if (IsCellEmpty(x, z) == 0)
        {
            grid[x, z] = objectToPlace;
            objectToPlace.gameObject.transform.position = GetCellCenter(x, z);
            return true;
        }
        else
        {
            var objectCollided= grid[x, z].gameObject.GetComponent<IGridCollidable>();
            var movingObject = objectToPlace.gameObject.GetComponent<IGridCollidable>();
            if (objectCollided != null && movingObject != null) {
                objectCollided.OnGridCollision(movingObject);
            } 
            
        }
        return false;
    }
    public void RemoveObjectFromCell(int x, int z) {
        grid[x, z] = null;
    }
}

public class CellData {
    public GameObject gameObject;
    public int value;

    public CellData(GameObject obj, int value) {
        gameObject = obj;
        this.value = value;
    }
}