using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] Transform a, b;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startPoint = 0.5f;

    [SerializeField] Color color1, color2;

    Transform currentTarget;

    void OnValidate()
    {
        SetupStartPoint();
    }

    void Start()
    {
        currentTarget = b;
        SetupStartPoint();
    }
    void SetupStartPoint()
    {
        transform.position = Vector3.Lerp(a.position, b.position, startPoint);
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
        {
            currentTarget = currentTarget == a ? b : a;
        }
    }

    void OnDrawGizmos()
    {
        if (a == null || b == null)
            return;

        Gizmos.color = Color.Lerp(color1, color2, startPoint);
        Gizmos.DrawSphere(a.position, 0.25f);
        Gizmos.DrawSphere(b.position, 0.25f);
        Gizmos.DrawLine(a.position, b.position);
    }
}
