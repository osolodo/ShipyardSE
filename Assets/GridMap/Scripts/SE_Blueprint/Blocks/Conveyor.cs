using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_Conveyor")]
[
    XmlInclude(typeof(ConveyorConnector))
]
public class Conveyor : CubeBlock {}