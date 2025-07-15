using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Utility
{
    public static Rect GetRect(this Camera cam)
    {
        float sizeY = cam.orthographicSize * 2;
        Vector2 cameraSize = new(sizeY * cam.aspect, sizeY);
        Vector2 cameraCentre = cam.transform.position;

        Rect cameraRect = new(cameraCentre - (cameraSize / 2), cameraSize);
        return cameraRect;
    }

    public static Rect GetRect(this Collider2D myCollider2D)
    {
        Bounds bounds = myCollider2D.bounds;
        return new(bounds.min, bounds.size);
    }

    public static Vector2 GetRandomPoint(this Rect rect)
    {
        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);
        return new(x, y);
    }
    public static Vector2 GetRandomPoint(this Rect rect, System.Random random)
    {
        float x = Mathf.Lerp(rect.xMin, rect.xMax,(float) random.NextDouble());
        float y = Mathf.Lerp(rect.yMin, rect.yMax, (float)random.NextDouble());
        return new(x, y);
    }

    public static Quaternion LookRotation2D(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        return Quaternion.Euler(0, 0, angle);
    }

    public static float Range(this System.Random random, float minValue, float maxValue)
    {
        double t = random.NextDouble();
        return Mathf.Lerp(minValue, maxValue, (float)t);
    }

    public static Vector2 InsideUnitCircle(this System.Random random)
    {
        float a = (float)random.NextDouble() * Mathf.PI * 2;
        Vector2 dir = new(Mathf.Cos(a), Mathf.Sin(a));  // Irány: Egység vektor
        float m = (float)random.NextDouble();           // Hossz
        return dir * m;
    }

    public static Vector2 OnUnitCircle(this System.Random random)
    {
        float a = (float)random.NextDouble() * Mathf.PI * 2;
        return new(Mathf.Cos(a), Mathf.Sin(a));  // Irány: Egység vektor
    }
}
