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
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
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

        // Vector2 targetPoint = Random.insideUnitCircle * randomRadius;

        float dist = Vector2.Distance(transform.position, targetPoint);
        float currentSmoothTime = smoothTime * dist;
        while (Vector2.Distance(transform.position, targetPoint) > 0.01f)
        {
            transform.position =
                Vector2.SmoothDamp(transform.position, targetPoint, ref velocity, currentSmoothTime, maxSpeed, Time.deltaTime);
            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, randomRadius);
    }
}
