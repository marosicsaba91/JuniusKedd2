using UnityEngine;

public class CollisionDamager : MonoBehaviour
{
    [SerializeField] float minDamage = 10;
    [SerializeField] float maxDamage = 20;
    [SerializeField] float minSpeedToDamage = 5;
    [SerializeField] float maxDamageSpeed = 20;

    void OnCollisionEnter(Collision collision) => 
        Damage(collision.gameObject, collision.relativeVelocity.magnitude);
    void OnCollisionEnter2D(Collision2D collision) => 
        Damage(collision.gameObject, collision.relativeVelocity.magnitude);

    void Damage(GameObject gameObject, float relativeSpeed)
    {
        if (relativeSpeed < minSpeedToDamage)
            return;

        if (gameObject.TryGetComponent(out Damageable damageable))
        {
            float t = Mathf.InverseLerp(minSpeedToDamage, maxDamageSpeed, relativeSpeed);
            float damage = Mathf.Lerp(minDamage, maxDamage, t);

            damageable.Damage(damage);
        }
    }
}