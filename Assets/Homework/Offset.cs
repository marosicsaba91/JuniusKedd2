using UnityEngine;

public class Offset : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxDistance;

    Vector3 startPoint;
    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        Vector3 step = (target.position - startPoint);
        step = Vector3.ClampMagnitude(step, maxDistance);
        transform.position = startPoint + step;
    }

}
