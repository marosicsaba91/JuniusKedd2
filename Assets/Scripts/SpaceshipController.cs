using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float acceleration = 10;
    [SerializeField] float maxSpeed = 20;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float drag = 1;

    void Update()
    {     
        // transform.position += velocity * Time.deltaTime;

        float hInput = Input.GetAxisRaw("Horizontal");
        float rotation = -hInput * angularSpeed * Time.deltaTime;
        // transform.Rotate(0, 0, rotation);
        rigidBody.rotation += rotation; 
    }

    void FixedUpdate()
    {
        float vInput = Input.GetAxisRaw("Vertical");
        Vector2 accelerationVector = acceleration * transform.up * vInput;

        Vector2 velocity = rigidBody.linearVelocity;
        velocity += accelerationVector * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector2 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;
        rigidBody.linearVelocity = velocity;
    }



}
