using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWorld {

    private int width;
    private int height;
    private float cellSize;
    private float cellSizeX;
    private float cellSizeZ;
    private int[,] gridArray;
    private Vector3 from;
    private Vector3 to;


    public GridWorld(int width, int height, float cellSize){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width,height];

        for ( int x = 0; x < gridArray.GetLength(0); x++){
            for( int z = 0; z < gridArray.GetLength(1); z++){
                Debug.DrawLine(GetWorldPosition(x,0,z) * cellSize, GetWorldPosition(x,0,z+1) * cellSize, Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,0,z) * cellSize, GetWorldPosition(x+1,0,z) * cellSize, Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,0,height) * cellSize, GetWorldPosition(width,0,height) * cellSize, Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0,0) * cellSize, GetWorldPosition(width,0,height) * cellSize, Color.white, 100f);
    }

    public GridWorld(int width, int height, Vector3 from, Vector3 to){
        this.width = width;
        this.height = height;
        cellSizeX = Mathf.Abs(from.x - to.x)/width;
        cellSizeZ = Mathf.Abs(from.z - to.z)/height;

        this.from = from;
        this.to = to;
        gridArray = new int[width,height];
        for ( int x = 0; x < gridArray.GetLength(0); x++){
            for( int z = 0; z < gridArray.GetLength(1); z++){
                Debug.DrawLine(GetWorldPosition(from.x + x * cellSizeX,0,from.z + z * cellSizeZ), GetWorldPosition(from.x + x * cellSizeX,0,from.z + (z + 1) * cellSizeZ), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(from.x + x * cellSizeX,0,from.z + z * cellSizeZ), GetWorldPosition(from.x + (x + 1) * cellSizeX,0,from.z + z * cellSizeZ), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(from.x,0,from.z + height * cellSizeZ), GetWorldPosition(from.x + width * cellSizeX,0,from.z + height * cellSizeZ), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(from.x + width * cellSizeX,0,from.z), GetWorldPosition(from.x + width * cellSizeX,0,from.z + height * cellSizeZ), Color.white, 100f);
        
    }


    private Vector3 GetWorldPosition(float x, float y, float z){
        return new Vector3(x,y,z);
    }

    public void GetXZ(Vector3 worldPosition, out int x, out int z){
        if(worldPosition.x >= from.x && worldPosition.z >= from.z && worldPosition.x <= to.x && worldPosition.z <= to.z){
            x = Mathf.FloorToInt((worldPosition.x + Mathf.Abs(from.x - to.x)/2) / cellSizeX);
            z = Mathf.FloorToInt((worldPosition.z + Mathf.Abs(from.z - to.z)/2) / cellSizeZ);
        }
        else{
            x = 10000;
            z = 10000;
        }
    }

    public Vector3 getCellPosition(int x, int z){
        Vector3 cellPosition = Vector3.zero;
        cellPosition.x = from.x + cellSizeX * x;
        cellPosition.z = from.z + cellSizeZ * z;
        return cellPosition;
    }

    public Vector3 getFrom(){
        return from;
    }

    public Vector3 getTo(){
        return to;
    }
    
    public float getCellSizeX(){
        return cellSizeX;
    } 

    public float getCellSizeZ(){
        return cellSizeZ;
    } 

}
