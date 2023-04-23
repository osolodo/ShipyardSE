using System.Xml.Serialization;

public class BlockOrientation
{
    [XmlAttribute("Forward")]
    public string Forward;
    [XmlAttribute("Up")]
    public string Up;
}