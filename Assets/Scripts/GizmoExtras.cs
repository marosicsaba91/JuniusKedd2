using UnityEngine;

public static class GizmoExtras 
{
    public static void DrawCircle(Vector3 position, float radius, int pointCount = 30)
    {
        Vector3 p1 = GetCirclePoint(position, radius, 0);

        for (int i = 1; i <= pointCount; i++)
        {
            float rad = (float)i / pointCount * 360f * Mathf.Deg2Rad;
            Vector3 p2 = GetCirclePoint(position, radius, rad);
            Gizmos.DrawLine(p1, p2);

            p1 = p2;
        }
    }

    static Vector3 GetCirclePoint(Vector3 position, float radius, float rad)
    {
        Vector3 p = new(Mathf.Cos(rad), Mathf.Sin(rad));
        p *= radius;
        p += position;
        return p;
    }
}
