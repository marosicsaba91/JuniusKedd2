using UnityEngine;
using UnityEngine.UIElements;

public class FlyingCar : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] AnimationCurve speedByDistance;
    [SerializeField] float angularSpeed = 180;

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 distanceVec = target.position - position;
        float distance = distanceVec.magnitude;

        Quaternion targetRotation = Quaternion.LookRotation(distanceVec);

        Quaternion rotation = distance == 0 ? transform.rotation :
            Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);

        float speed = speedByDistance.Evaluate(distance);
        position += speed * Time.deltaTime * transform.forward;

        transform.SetPositionAndRotation(position, rotation);
    }
}
