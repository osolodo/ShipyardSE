using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_ConveyorSorter")]
public class Sorter : FunctionalBlock
{
    public bool IsWhiteList;
    // public bool DefinitionIds
    // public bool DefinitionTypes
    public bool DrainAll;
}