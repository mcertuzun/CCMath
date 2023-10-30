using Shapes;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class UnitCircle : ImmediateModeShapeDrawer
{
    public Transform origin;
    private readonly Color32 white = new Color32(255, 255, 255, 100);
 
    public override void DrawShapes(Camera cam)
    {
        base.DrawShapes(cam);

        using (Draw.Command(cam))
        {
            Draw.Thickness = 0.05f;
            Draw.Opacity = 1f;
            Draw.Color = white;
            Draw.Ring(new Vector3(0, 0, 0), 1);
        }
    }
}