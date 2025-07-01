using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    [SerializeField] float randomRange = 10;

    List<Vector3> points = new();

    void Update()
    {
        Vector2 p = (Vector2)transform.position + GetPointInsideUnitCircle() * randomRange;
        points.Add(p);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, randomRange);

        foreach (var p in points)
            Gizmos.DrawSphere(p, 0.05f);
    }


    Vector2 GetPointInsideUnitCircle()
    {
        float distance = Random.Range(0f, 1f);
        float angle = Random.Range(0f, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return Mathf.Sqrt(distance) * direction;
    }
}
