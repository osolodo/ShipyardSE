using UnityEngine;

public readonly struct BlockManager
{
    public CubeBlock block { get; }

    public Transform instance { get; }

    public BlockManager(CubeBlock block, Transform instance){
        this.block = block;
        this.instance = instance;
    }

    public override string ToString() => $"{block.SubtypeName} ({block.EntityId})";
}