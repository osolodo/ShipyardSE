using System.Xml.Serialization;

public class SerializableVector3
{
    [XmlAttribute("x")]
    public float x;

    [XmlAttribute("y")]
    public float y;

    [XmlAttribute("z")]
    public float z;
    
    public override string ToString() => $"({x}, {y}, {z})";
    
    public static implicit operator UnityEngine.Vector3(SerializableVector3 v) => new UnityEngine.Vector3(-v.x,v.y,v.z);
}