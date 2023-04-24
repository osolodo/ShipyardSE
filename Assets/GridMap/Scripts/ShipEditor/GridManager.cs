using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridManager : MonoBehaviour
{
    private float cubeSize = 2.5f;
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs {
        public Vector3Int positionMin;
        public Vector3Int positionMax;
    }
    private List<BlockManager> blockList = new List<BlockManager>();

    private Vector3Int Max;
    private Vector3Int Min;

    public Vector3 Center;

    private GridManager(){
    }

    private void instantiate(CubeGrid cubeGrid){
        
        this.transform.localPosition = Vector3.zero;
        this.transform.localEulerAngles = Vector3.zero;
        cubeSize = (GridSize)cubeGrid.GridSizeEnum;
        cubeGrid.CubeBlocks.ForEach( (CubeBlock block) => {
            Transform instance = Instantiate(block.Prefab(), GetRelativePosition(block.Min), Quaternion.identity);
            instance.localScale *= cubeSize;
            instance.parent = transform;
            this.SetGridObject(block.Min, new BlockManager(block,instance));
        });
        Center = ((Vector3)Max-Min)/2;

        bool showDebug = true;
        if(showDebug) {
            Vector3 c = GetWorldPosition(Vector3Int.RoundToInt(Center));
            Vector3Utils.DebugDrawCube(GetWorldPosition(Min),GetWorldPosition(Max), Color.blue);
            Vector3Utils.DebugDrawCube(c-Vector3Int.one,c+Vector3Int.one, Color.red);
            // OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) => {
            // };
        }
    }

    private static string GetName(CubeGrid cubeGrid) {
        return String.IsNullOrWhiteSpace(cubeGrid.DisplayName) ?
            cubeGrid.EntityId.ToString() :
            cubeGrid.DisplayName;
    }

    public static GridManager MakeGrid(CubeGrid cubeGrid, ShipManager parent){
        GameObject self = new GameObject(GetName(cubeGrid),typeof(GridManager));
        Debug.Log("Creating Grid: "+self.name);
        self.transform.parent = parent.transform;
        self.GetComponent<GridManager>().instantiate(cubeGrid);
        return self.GetComponent<GridManager>();
    }

    public Vector3 GetWorldPosition(Vector3Int pos) {
        return this.transform.TransformVector(((Vector3)pos) * cubeSize);
    }

    public Vector3 GetCenterWorldPosition() {
        return this.transform.TransformVector(Center * cubeSize);
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

    public void SetGridObject(Vector3Int position, BlockManager value) {
        blockList.Add(value);
        // TODO: This will only ever grow, need something else for removing blocks
        // Also wrong on instatiation, so fix that eventually
        Min = Vector3Int.Min(Min,position);
        Max = Vector3Int.Max(Max,position+Vector3Int.one);
        TriggerGridObjectChanged(position);
    }

    public void SetGridObject(Vector3 worldPosition, BlockManager value) {
        SetGridObject(GetGridPosition(worldPosition),value);
    }

    public void TriggerGridObjectChanged(Vector3Int position){
        if(OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs {positionMin = position, positionMax = position});
    }

    public BlockManager GetGridObject(Vector3 worldPosition) {
        return GetGridObject(GetGridPosition(worldPosition));
    }

    public BlockManager GetGridObject(Vector3Int position) {
        return blockList.Find((BlockManager element)=>{
            return false;
        });
    }

    public float GetCubeSize() {
        return cubeSize;
    }
}
