using UnityEngine;
using UnityEngine.UIElements;

public class PoseDrawer : MonoBehaviour
{
    [SerializeField] float length = 1;

    void OnDrawGizmos()
    {
        Vector3 p = transform.position;

        DrawAxis(p, transform.right, Color.red);
        DrawAxis(p, transform.up, Color.green);
        DrawAxis(p, transform.forward, Color.blue);
    }

    void DrawAxis(Vector3 p, Vector3 direction, Color colour)
    {
        Gizmos.color = colour;
        Gizmos.DrawLine(p + direction * length, p - direction * length);
        Gizmos.DrawSphere(p + direction * length, 0.1f * length);
    }
}
