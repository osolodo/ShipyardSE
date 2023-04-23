using UnityEngine;

public class SerializableQuaternion
{
    public float X;

    public float Y;

    public float Z;

    public float W;
    public SerializableQuaternion(float X, float Y, float Z, float W){
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.W = W;
    }
    
    public override string ToString() => $"({X}, {Y}, {Z}, {W})";
    public SerializableQuaternion(){}
    public static implicit operator Quaternion(SerializableQuaternion q) => new Quaternion(q.X, q.Y, q.Z, q.W);
    public static explicit operator SerializableQuaternion(Quaternion q) => new SerializableQuaternion(q.x, q.y, q.z, q.w);
    
}