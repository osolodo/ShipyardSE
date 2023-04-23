using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private Transform testTransform;
    [SerializeField] public Transform shipPosition;

    private ShipBlueprint shipBlueprint;

    private List<BlockGrid> grids = new List<BlockGrid>();


    public void SetShipBlueprint(ShipBlueprint blueprint){
        this.shipBlueprint = blueprint;
        Cleanup();
        blueprint.cubeGrids.ForEach( (cubeGrid) => {
            grids.Add(BlockGrid.MakeGrid(cubeGrid,this));
        });
    }

    public void Cleanup(){
        grids.ForEach( grid => GameObject.Destroy(grid) );
        grids.Clear();
    }
}
