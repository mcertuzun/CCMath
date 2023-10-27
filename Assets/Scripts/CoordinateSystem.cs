using UnityEditor;
using UnityEngine;

public class CoordinateSystem : MonoBehaviour

{
    public int xCount= 5 , yCount = 5;
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawLine(Vector2.right * -xCount,Vector2.right * xCount, 2f);
        
        Handles.color = Color.green;
        Handles.DrawLine(Vector2.up * -yCount,Vector2.up * yCount, 2f);

        for (int x = -xCount; x <= xCount; x++)
        {
          
                
                drawString($"({x},{0})", new Vector2(x, 0), Color.black, Vector2.up,10f);
                // Handles.color = Color.black;
                // Handles.Label( new Vector2(x,y), $"({x},{y})" );
        } for (int y = -xCount; y <= xCount; y++)
        {
          
                
                drawString($"({0},{y})", new Vector2(0, y), Color.black, Vector2.right,10f);
                // Handles.color = Color.black;
                // Handles.Label( new Vector2(x,y), $"({x},{y})" );
        }
    }
    public static void drawString(string text, Vector3 worldPosition, Color textColor, Vector2 anchor, float textSize = 15f)
    {
#if UNITY_EDITOR
        var view = UnityEditor.SceneView.currentDrawingSceneView;
        if (!view)
            return;
        Vector3 screenPosition = view.camera.WorldToScreenPoint(worldPosition);
        if (screenPosition.y < 0 || screenPosition.y > view.camera.pixelHeight || screenPosition.x < 0 || screenPosition.x > view.camera.pixelWidth || screenPosition.z < 0)
            return;
        var pixelRatio = UnityEditor.HandleUtility.GUIPointToScreenPixelCoordinate(Vector2.right).x - UnityEditor.HandleUtility.GUIPointToScreenPixelCoordinate(Vector2.zero).x;
        UnityEditor.Handles.BeginGUI();
        var style = new GUIStyle(GUI.skin.label)
        {
            fontSize = (int)textSize,
            normal = new GUIStyleState() { textColor = textColor }
        };
        Vector2 size = style.CalcSize(new GUIContent(text)) * pixelRatio;
        var alignedPosition =
            ((Vector2)screenPosition +
             size * ((anchor + Vector2.left + Vector2.up) / 2f)) * (Vector2.right + Vector2.down) +
            Vector2.up * view.camera.pixelHeight;
        GUI.Label(new Rect(alignedPosition / pixelRatio, size / pixelRatio), text, style);
        UnityEditor.Handles.EndGUI();
#endif
    }
    
}