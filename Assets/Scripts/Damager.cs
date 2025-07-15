using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] bool destroyOnDamage = true;

    void OnTriggerEnter(Collider other) => Damage(other.gameObject);
    void OnTriggerEnter2D(Collider2D other) => Damage(other.gameObject);


    void Damage(GameObject go)
    {
        Damageable damageable = go.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.Damage(damage);

            if (destroyOnDamage)
                Destroy(gameObject);
        }
    }
}
