using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_AirVent")]
public class Airvent : FunctionalBlock
{
    public bool IsDepressurizing;
}