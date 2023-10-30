using System;
using Shapes;
using UnityEngine;
using UnityEngine.Events;

public class DotProduct : ImmediateModeShapeDrawer
{
    public Transform origin, a, b;
    private Vector3 bTemp, projection;
    public UnityEvent OnSameDirection, OnOppositeDirection, OnPerpendicularUp, OnPerpendicularDown;
    private int currentVal;

    private void Awake()
    {
        bTemp = b.position;
    }

    private void FixedUpdate()
    {
        EventTrigger();
    }

    private void EventTrigger()
    {
        if (Math.Abs(projection.x - 1.0f) < 0.025f && currentVal != 1)
        {
            currentVal = 1;
            OnSameDirection?.Invoke();
        }

        if (Math.Abs(projection.x - (-1.0f)) < 0.025f && currentVal != -1)
        {
            currentVal = -1;
            OnOppositeDirection?.Invoke();
        }

        if (Math.Abs(projection.x - (0)) <= 0.025f)
        {
            if (currentVal == 1)
            {
                OnPerpendicularUp?.Invoke();
            }
            else if (currentVal == -1)
            {
                OnPerpendicularDown?.Invoke();
            }
        }
    }

    public override void DrawShapes(Camera cam)
    {
        base.DrawShapes(cam);

        using (Draw.Command(cam))
        {
            Draw.Thickness = 0.05f;
            Draw.LineEndCaps = LineEndCap.Round;
            Draw.Color = new Color32(255, 255, 255, 255);

            var originPosition = origin.position;
            var aPosition = a.position;
            var bPosition = b.position;
            projection = Vector3.Project(aPosition, bPosition);


            DrawArrowLine(originPosition, bTemp);
            DrawArrowLine(originPosition, aPosition);
            DrawProjectionLine(originPosition, projection);
            DrawDashedDropLine(aPosition, projection);

            a.RotateAround(originPosition, Vector3.forward, 45 * Time.deltaTime);
        }
    }

    private static void DrawArrowLine(Vector3 originPosition, Vector3 targetPos)
    {
        Draw.Line(originPosition, targetPos);
        var direction = targetPos - originPosition;
        Draw.Cone(targetPos, direction, 0.075f, 0.15f);
    }

    private void DrawProjectionLine(Vector3 originPosition, Vector3 projection)
    {
        var TextPos = (originPosition + projection) / 2 + Vector3.down * 0.1f;
        Draw.Text(TextPos, projection.x.ToString("0.00"));

        Draw.Color = new Color32(94, 175, 226, 225);
        Draw.Thickness = 0.075f;
        Draw.Line(originPosition, projection);
    }

    private static void DrawDashedDropLine(Vector3 aPosition, Vector3 projection)
    {
        Draw.UseDashes = true;
        Draw.Thickness = 0.015f;
        Draw.DashStyle = new DashStyle()
        {
            size = 1f,
            spacing = 1f,
            type = DashType.Rounded,
            snap = DashSnapping.EndToEnd,
            space = DashSpace.Relative
        };
        Draw.Color = BlueColor;
        Draw.Line(aPosition, projection);
    }

    private static Color32 BlueColor => new(255, 255, 255, 100);
}