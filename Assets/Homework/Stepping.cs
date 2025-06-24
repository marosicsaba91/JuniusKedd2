using UnityEngine;

public class Stepping : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 target;
    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (transform.position == target)
        {
            Vector2 step = Vector2.zero;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                step = Vector2.right;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                step = Vector2.left;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                step = Vector2.up;
            if (Input.GetKeyDown(KeyCode.DownArrow))
                step = Vector2.down;

            target += (Vector3)step;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
