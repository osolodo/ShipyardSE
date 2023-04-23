using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_InteriorLight")]
public class InteriorLight : FunctionalBlock
{
    public float Radius;
    public float ReflectorRadius;
    public float Falloff;
    public float Intensity;
    public float BlinkIntervalSeconds;
    public float BlinkLenght;
    public float BlinkOffset;
    public float Offset;
}