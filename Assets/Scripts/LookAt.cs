using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
