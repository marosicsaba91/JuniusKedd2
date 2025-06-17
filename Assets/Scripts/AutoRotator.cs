using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    [SerializeField] Vector3 angularVelocity = new(0, 360, 0);
    [SerializeField] Space rotationSpace = Space.World;

    void Update()
    {
        transform.Rotate(angularVelocity * Time.deltaTime, rotationSpace);
    }
}
