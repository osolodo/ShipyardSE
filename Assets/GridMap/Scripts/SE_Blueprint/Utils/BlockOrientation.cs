using System.Xml.Serialization;

public class BlockOrientation
{
    [XmlAttribute("Forward")]
    public string Forward;
    [XmlAttribute("Up")]
    public string Up;

    public override string ToString() => $"Forward:{Forward}\nUp:{Up}";
}