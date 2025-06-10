using UnityEngine;

class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0)] float speed = 1;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new(x, 0, y);
        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

        Debug.Log("Mod");
    }
}
