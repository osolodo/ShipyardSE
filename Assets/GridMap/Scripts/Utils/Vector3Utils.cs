using UnityEngine;
public abstract class Vector3Utils
{
    public static void DebugDrawCube(Vector3 Min, Vector3 Max, Color color){
            Debug.DrawLine(Min,new Vector3(Max.x,Min.y,Min.z), color, 100f);
            Debug.DrawLine(Min,new Vector3(Min.x,Max.y,Min.z), color, 100f);
            Debug.DrawLine(Min,new Vector3(Min.x,Min.y,Max.z), color, 100f);
            
            Debug.DrawLine(Max,new Vector3(Min.x,Max.y,Max.z), color, 100f);
            Debug.DrawLine(Max,new Vector3(Max.x,Min.y,Max.z), color, 100f);
            Debug.DrawLine(Max,new Vector3(Max.x,Max.y,Min.z), color, 100f);

            Debug.DrawLine(new Vector3(Min.x,Max.y,Min.z), new Vector3(Max.x,Max.y,Min.z), color, 100f);
            Debug.DrawLine(new Vector3(Min.x,Min.y,Max.z), new Vector3(Max.x,Min.y,Max.z), color, 100f);

            Debug.DrawLine(new Vector3(Min.x,Min.y,Max.z),new Vector3(Min.x,Max.y,Max.z), color, 100f);
            Debug.DrawLine(new Vector3(Max.x,Min.y,Min.z),new Vector3(Max.x,Max.y,Min.z), color, 100f);

            Debug.DrawLine(new Vector3(Min.x,Max.y,Min.z),new Vector3(Min.x,Max.y,Max.z), color, 100f);
            Debug.DrawLine(new Vector3(Max.x,Min.y,Min.z),new Vector3(Max.x,Min.y,Max.z), color, 100f);
    }
}