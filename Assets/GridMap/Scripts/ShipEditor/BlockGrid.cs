using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BlockGrid : MonoBehaviour
{
    private float cubeSize = 2.5f;
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs {
        public Vector3Int positionMin;
        public Vector3Int positionMax;
    }
    private List<Block> blockList = new List<Block>();

    private BlockGrid(){
    }

    private void instantiate(CubeGrid cubeGrid){
        
        this.transform.localPosition = Vector3.zero;
        this.transform.localEulerAngles = Vector3.zero;
        cubeSize = cubeGrid.GridSizeEnum == GridSizeEnum.Large ? 2.5f : 0.5f;

        Debug.Log("Blocks: "+cubeGrid.CubeBlocks.Count);
        cubeGrid.CubeBlocks.ForEach( (CubeBlock block) => {
            this.SetGridObject(block.Min, new Block(block,this));
        });

        /**
        bool showDebug = false;
        if(showDebug) {
            TextMesh[,] debugTextArray = new TextMesh[width, height];
            for (int x=0; x<gridArray.GetLength(0); x++){
                for (int y=0; y<gridArray.GetLength(1); y++){
                    debugTextArray[x,y] = UtilsClass.CreateWorldText(gridArray[x,y]?.ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize,cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y+1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1,y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width, height), Color.white, 100f);

            OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) => {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }
        */
    }

    private static string GetName(CubeGrid cubeGrid) {
        return String.IsNullOrWhiteSpace(cubeGrid.DisplayName) ?
            cubeGrid.EntityId.ToString() :
            cubeGrid.DisplayName;
    }

    public static BlockGrid MakeGrid(CubeGrid cubeGrid, ShipManager parent){
        GameObject self = new GameObject(GetName(cubeGrid),typeof(BlockGrid));
        Debug.Log("Creating Grid: "+self.name);
        self.transform.parent = parent.transform;
        self.GetComponent<BlockGrid>().instantiate(cubeGrid);
        Debug.Log("Grid Created");
        return self.GetComponent<BlockGrid>();
    }

    public Vector3 GetWorldPosition(Vector3Int pos) {
        return this.transform.TransformVector(((Vector3)pos) * cubeSize);
    }

    public Vector3 GetRelativePosition(Vector3Int pos) {
        return ((Vector3)pos) * cubeSize;
    }

    private Vector3Int GetGridPosition(Vector3 worldPosition) {
        Vector3 relativePosition = this.transform.InverseTransformVector(worldPosition);
        int x = Mathf.FloorToInt(relativePosition.x/cubeSize);
        int y = Mathf.FloorToInt(relativePosition.y/cubeSize);
        int z = Mathf.FloorToInt(relativePosition.z/cubeSize);
        return new Vector3Int(x,y,z);
    }

    public void SetGridObject(Vector3Int position, Block value) {
        //TODO: check validity
        blockList.Add(value);
        TriggerGridObjectChanged(position);
    }

    public void SetGridObject(Vector3 worldPosition, Block value) {
        SetGridObject(GetGridPosition(worldPosition),value);
    }

    public void TriggerGridObjectChanged(Vector3Int position){
        if(OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs {positionMin = position, positionMax = position});
    }

    public Block GetGridObject(Vector3 worldPosition) {
        return GetGridObject(GetGridPosition(worldPosition));
    }

    public Block GetGridObject(Vector3Int position) {
        return blockList.Find((Block element)=>{
            return false;
        });
    }

    public float GetCubeSize() {
        return cubeSize;
    }
}
