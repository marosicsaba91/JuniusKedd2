using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform followed;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, followed.position, speed * Time.deltaTime);

        Vector3 direction = followed.position - transform.position;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
