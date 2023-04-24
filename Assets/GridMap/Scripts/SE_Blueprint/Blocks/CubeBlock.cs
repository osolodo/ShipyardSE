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
        if(SubtypeName != null && SubtypeName.Length > 15 &&
        (SubtypeName.StartsWith("LargeBlockArmor") ||
        SubtypeName.StartsWith("SmallBlockArmor"))) {
            string substring = SubtypeName[15..];
            attempt = Resources.Load<Transform>($"Prefabs/Blocks/{substring}");
        }
        return attempt ?? Resources.Load<Transform>("Prefabs/Blocks/Block");
    }

}