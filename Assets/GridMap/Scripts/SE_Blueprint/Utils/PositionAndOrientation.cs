public class PositionAndOrientation
{
    public SerializableVector3 Position;
    public SerializableVector3 Forward;
    public SerializableVector3 Up;
    public SerializableQuaternion Orientation;
    
    public override string ToString() => $"Position:{Position}\nForward:{Forward}\nUp:{Up}\nOrientation:{Orientation}";
}