using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlType(TypeName = "MyObjectBuilder_ShipBlueprintDefinition")]
public class ShipBlueprint
{
    public ID Id;
    public string DisplayName;
    
    [XmlElement("DLC")]
    public List<string> DLC;

    [XmlArray("CubeGrids"),XmlArrayItem("CubeGrid")]
    public List<CubeGrid> cubeGrids;

    public string EnvironmentType;
    public string WorkshopId;
    public string OwnerSteamId;
    public string Points;
    
    
    public static ShipBlueprint Load(string path)
    {
        var serializer = new XmlSerializer(typeof(Definitions));
        using(var stream = new FileStream(path, FileMode.Open))
        {
            Definitions definition = serializer.Deserialize(stream) as Definitions;
            if(definition.shipBlueprints.Count > 0){
                return definition.shipBlueprints[0];
            }
            return default(ShipBlueprint);
        }
    }
    
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(Definitions));
        using(var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, new Definitions(this));
        }
    }

    [XmlRoot("Definitions")]
    public class Definitions
    {
        [XmlArray("ShipBlueprints"),XmlArrayItem("ShipBlueprint")]
        public List<ShipBlueprint> shipBlueprints = new List<ShipBlueprint>();

        public Definitions(ShipBlueprint blueprint){
            shipBlueprints.Add(blueprint);
        }
        public Definitions(){}
    }

    public class ID {
        
        [XmlAttribute("Type")]
        public string Type = "MyObjectBuilder_ShipBlueprintDefinition";

        [XmlAttribute("Subtype")]
        public string Subtype;
    }
}
