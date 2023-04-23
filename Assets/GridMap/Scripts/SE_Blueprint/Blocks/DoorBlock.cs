using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_Door")]
[XmlInclude(typeof(AirtightSlideDoor))]
public class DoorBlock : FunctionalBlock
{
    public bool AnyoneCanUse;
    public double Opening;
    public string OpenSound;
    public string CloseSound;
}

[XmlType(TypeName = "MyObjectBuilder_AirtightSlideDoor")]
public class AirtightSlideDoor : DoorBlock {}