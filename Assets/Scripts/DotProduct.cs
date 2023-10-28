using UnityEditor;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public Transform aTransform, bTransform, cTransform, dTransform;

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Vector2 a = aTransform.position;
        Vector2 b = bTransform.position;
        Vector2 c = cTransform.position;
        
        Vector2 AB = (b - a);
        Vector2 AC = (c - a);

        var proj = Project(AB, AC);
        
        
        var projection = Vector3.Project(AB, AC);
        dTransform.position = projection;
        Handles.color = Color.yellow;
        Handles.DrawDottedLine(b,proj, 2);
        Handles.Label(Vector2.Lerp(a, projection, 0.5f), "${}");
        Handles.color = Color.black;
        Handles.DrawSolidDisc(a, Vector3.forward, 0.1f);
        Handles.Label(a, "A");
        Handles.DrawSolidDisc(b, Vector3.forward, 0.1f);
        Handles.Label(b, "B");
        Handles.DrawSolidDisc(c, Vector3.forward, 0.1f);
        Handles.Label(c, "C");  
        Handles.DrawSolidDisc(projection, Vector3.forward, 0.1f);
        Handles.Label(projection, "D");

        Handles.color = Color.red;
        Handles.DrawLine(a, b, 1f);
        Handles.color = Color.green;
        Handles.DrawLine(a, c,1);
        Handles.color = Color.blue;
        Handles.DrawLine(a, projection, 5f);
    }
    
    public static Vector3 Project(Vector3 vector, Vector3 onNormal)
    {
        float num1 = Vector3.Dot(onNormal, onNormal);
        float num2 = Vector3.Dot(vector, onNormal);
        return new Vector3(onNormal.x * num2 / num1, onNormal.y * num2 / num1, onNormal.z * num2 / num1);
    }

#endif
}