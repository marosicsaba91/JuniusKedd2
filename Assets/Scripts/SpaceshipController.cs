using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 20;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float drag = 1;

    Vector3 velocity;

    void Update()
    {     
        transform.position += velocity * Time.deltaTime;

        float hInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -hInput * angularSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        Vector3 accelerationVector = acceleration * transform.up * vInput;

        velocity += accelerationVector * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;
    }
}
