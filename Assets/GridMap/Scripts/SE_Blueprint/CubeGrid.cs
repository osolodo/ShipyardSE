using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class CubeGrid
{
    public string SubtypeName;
    public long EntityId;
    public string PersistentFlags = "CastShadows InScene";

    public PositionAndOrientation PositionAndOrientation;
    public GridSize.Enum GridSizeEnum = GridSize.Enum.Large;

    [XmlArray("CubeBlocks"),XmlArrayItem("MyObjectBuilder_CubeBlock")]
    public List<CubeBlock> CubeBlocks;

    public string DisplayName;
    public bool DestructibleBlocks = true;
    public bool IsRespawnGrid = false;

    [XmlArray("OxygenRooms"),XmlArrayItem("OxygenRoom")]
    public List<OxygenRoom> OxygenRooms;
}