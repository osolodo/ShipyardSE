using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_CubeBlock")]
[
    XmlInclude(typeof(FunctionalBlock)),
    XmlInclude(typeof(Passage)),
    XmlInclude(typeof(Ladder)),
    XmlInclude(typeof(ConveyorConnector))
]
public class CubeBlock
{
    public string SubtypeName;
    public long EntityId;
    public SerializableVector3Int Min;
    public BlockOrientation BlockOrientation;
    public SerializableVector3 ColorMaskHSV;
    public long BuiltBy;

    public Transform Prefab(){
        Transform attempt = null;
        //LargeBlockArmorCorner
        if(SubtypeName != null && SubtypeName.Length > 10 &&
        (SubtypeName.StartsWith("LargeBlock") ||
        SubtypeName.StartsWith("SmallBlock"))) {
            string substring = SubtypeName[10..];
            attempt = (Transform)Resources.Load<Transform>($"Blocks/{substring}");
        }
        return attempt ?? (Transform)Resources.Load<Transform>("Blocks/ArmorBlock");
    }

}