using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    private ShipBlueprint shipBlueprint;

    private List<GridManager> grids = new List<GridManager>();

    private CameraControl cameraControl;

    private void Awake() {
        cameraControl = transform.GetComponentInChildren<CameraControl>();
    }

    public void SetShipBlueprint(ShipBlueprint blueprint){
        this.shipBlueprint = blueprint;
        Cleanup();
        blueprint.cubeGrids.ForEach( (cubeGrid) => {
            grids.Add(GridManager.MakeGrid(cubeGrid,this));
        });
        cameraControl.Setup(grids[0].GetCenterWorldPosition(), 50, false);
    }

    public void Cleanup(){
        grids.ForEach( grid => GameObject.Destroy(grid) );
        grids.Clear();
    }
}
