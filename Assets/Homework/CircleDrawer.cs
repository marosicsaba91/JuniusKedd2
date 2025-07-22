using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float radius = 5;
    [SerializeField] int pointCount = 90;

    void OnValidate()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        UpdatePoints();
    }

    void Start()
    {
        UpdatePoints();
    }

    void UpdatePoints()
    {
        Vector3[] points = GetCirclePoint();
        lineRenderer.positionCount = pointCount;
        lineRenderer.SetPositions(points);
    }

    Vector3[] GetCirclePoint()
    {
        Vector3[] points = new Vector3[pointCount];
        for (int i = 0; i < pointCount; i++)
        {
            float angle = ((float)i / pointCount) * Mathf.PI * 2;
            Vector3 p = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            points[i] = p;
        }
        return points;
    }
}
