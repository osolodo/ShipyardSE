using System.Xml.Serialization;

public class OxygenRoom
{
    [XmlAttribute("OxygenAmount")]
    public double OxygenAmount;

    public Position StartingPosition;

    public struct Position{
        public int X;
        public int Y;
        public int Z;
    }
}