using UnityEngine;

class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0)] float baseSpeed = 10;
    [SerializeField, Min(0)] float dashSpeed = 20;
    [SerializeField, Min(0)] float dashTime = 0.5f;
    [SerializeField, Min(0)] float dashCooldown = 2f; 

    [SerializeField] float angularSpeed = 360f;
    [SerializeField] Transform cameraTransform;

    float currentSpeed;
    float dashTimer;

    void Update()
    {
        currentSpeed = Mathf.Max(currentSpeed, baseSpeed);
        if (dashTimer <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = dashSpeed;
            dashTimer = dashCooldown;
        }

        dashTimer = Mathf.Max(dashTimer - Time.deltaTime, 0);

        float deceleration = (dashSpeed - baseSpeed) / dashTime;
        currentSpeed = Mathf.MoveTowards(currentSpeed, baseSpeed, deceleration * Time.deltaTime);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 localDirection = new(x, 0, y);
        Vector3 direction = cameraTransform.TransformDirection(localDirection);
        direction.y = 0;
        direction.Normalize();

        Vector3 velocity = direction * currentSpeed;
        transform.position += velocity * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetQuaternion = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, angularSpeed * Time.deltaTime);
        }
    }
}
