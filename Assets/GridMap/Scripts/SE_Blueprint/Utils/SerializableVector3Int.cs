using System.Xml.Serialization;

public class SerializableVector3Int
{
    [XmlAttribute("x")]
    public int x;

    [XmlAttribute("y")]
    public int y;

    [XmlAttribute("z")]
    public int z;

    public override string ToString() => $"({x}, {y}, {z})";

    public static implicit operator UnityEngine.Vector3Int(SerializableVector3Int v) => new UnityEngine.Vector3Int(-v.x,v.y,v.z);
}