using UnityEditor;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public Transform aTransform, bTransform, cTransform;

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Vector2 a = aTransform.position;
        Vector2 b = bTransform.position;
        Vector2 c = cTransform.position;
        
        Vector2 AB = (b - a);
        Vector2 AC = (c - a);
        
        var projection = Vector3.Project(AB, AC);
    
       
        Handles.DrawDottedLine(b,projection, 4);
        
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
#endif
}