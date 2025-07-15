using System.Collections;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float maxSpeed = 30;
    [SerializeField] float smoothTime = 0.5f;
    [SerializeField] float randomRadius = 10;
    [SerializeField] float minWaitingTime = 1;
    [SerializeField] float maxWaitingTime = 2;
    [SerializeField] int shootCount = 1;
    [SerializeField] float shootDuration = 0.1f;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float minDistanceToTurn = 1; 

    [SerializeField] Projectile projectile;

    void OnEnable()
    {
        StartCoroutine(LifeCycle());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator LifeCycle()
    {
        while (true)
        {
            foreach (var w in MovePhase())
                yield return w;

            foreach (var w in ShootPhase())
                yield return w;

            float waitTime = Random.Range(minWaitingTime, maxWaitingTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    WaitForSeconds wait;
    IEnumerable ShootPhase()
    {
        SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
        Vector2 direction = (player.transform.position - transform.position).normalized;

        wait ??= new(shootDuration);

        for (int i = 0; i < shootCount; i++)
        {
            Quaternion rotation = Utility.LookRotation2D(direction);
            Instantiate(projectile, transform.position, rotation);
            yield return wait;
        }
    }

    IEnumerable MovePhase()
    {
        Vector2 velocity = Vector2.zero;

        Camera mainCamera = Camera.main;
        Rect cameraRect = Utility.GetRect(mainCamera);
        Vector2 targetPoint = cameraRect.GetRandomPoint();
        Vector2 direction2D = targetPoint - (Vector2)transform.position;
        Quaternion targetRotation = Utility.LookRotation2D(direction2D);
        Quaternion currentRotation = transform.rotation;

        while (currentRotation != targetRotation)
        {
            currentRotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularSpeed * Time.deltaTime);
            transform.rotation = currentRotation;
            yield return null;
        }

        float dist = Vector2.Distance(transform.position, targetPoint);
        float currentSmoothTime = smoothTime * dist;
        while (Vector2.Distance(transform.position, targetPoint) > 0.1f)
        {
            transform.position =
                Vector2.SmoothDamp(transform.position, targetPoint, ref velocity, currentSmoothTime, maxSpeed, Time.deltaTime);
            dist = Vector2.Distance(transform.position, targetPoint);
            if(dist < minDistanceToTurn)
            { 
                SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
                direction2D = (player.transform.position - transform.position);
                targetRotation = Utility.LookRotation2D(direction2D);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, randomRadius);
    }
}
