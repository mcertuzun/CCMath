using Shapes;
using UnityEngine;

[ExecuteAlways]
public class CoordinateAxis : ImmediateModeShapeDrawer
{
    public override void DrawShapes(Camera cam)
    {

        base.DrawShapes(cam);
        using (Draw.Command(cam))
        {
            Draw.Thickness = 0.025f;
            Draw.Line( Vector2.right * int.MinValue ,  Vector2.right * int.MaxValue, new Color32(255,0,0,50));
            Draw.Line( Vector2.up * int.MinValue,  Vector2.up * int.MaxValue, new Color32(0,255,0,50) );
        }
    }

  
}