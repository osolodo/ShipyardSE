using UnityEngine;

public class Block : MonoBehaviour
{
    private static Transform prefab = (Transform)Resources.Load<Transform>("Blocks/ArmorBlock");

    public CubeBlock block;

    private GameObject instance;

    private BlockGrid parent;

    public Block(CubeBlock block, BlockGrid parent){
        this.parent = parent;
        instance = Instantiate(prefab, parent.GetRelativePosition(block.Min), Quaternion.identity).gameObject;
        instance.transform.parent = parent.transform;
    }
}