using UnityEditor;
using UnityEngine;

public class CheckInside : MonoBehaviour
{
    public Transform baseObject, targetObject;
    [Range(0f, 10f)] [SerializeField] private float radius;

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Vector2 origin = baseObject.position;
        Vector2 targetPosition = targetObject.position;

        float distance = Vector2.Distance(origin, targetPosition);
       
        bool isInside = distance < radius;
        Debug.Log($"distance { distance} rad {radius}");
        Handles.color = isInside ? Color.green : Color.red;
        Handles.DrawWireDisc(origin, Vector3.forward, radius);
        
    }
#endif
} 