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

    public Transform prefab(){
        return (Transform)Resources.Load<Transform>("Blocks/ArmorBlock");
    }

}