using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform followed;
    [SerializeField, Min(0)] float speed = 5;
    [SerializeField, Min(0)] float minDistance = 2;

    void Update()
    {
        if(Vector3.Distance(followed.position, transform.position) > minDistance)
            transform.position = Vector3.MoveTowards(transform.position, followed.position, speed * Time.deltaTime);

        Vector3 direction = followed.position - transform.position;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
