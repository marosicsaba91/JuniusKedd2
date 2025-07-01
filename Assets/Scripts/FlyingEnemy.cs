using System.Collections;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float randomRadius = 10;
    [SerializeField] float minWaitingTime = 1;
    [SerializeField] float maxWaitingTime = 2;

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

            SpaceshipController player = FindAnyObjectByType<SpaceshipController>();
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            Instantiate(projectile, transform.position, rotation);

            float waitTime = Random.Range(minWaitingTime, maxWaitingTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerable MovePhase()
    {
        Vector2 targetPoint = Random.insideUnitCircle * randomRadius;
        while ((Vector2)transform.position != targetPoint)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
            yield return null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Vector3.zero, randomRadius);        
    }
}
