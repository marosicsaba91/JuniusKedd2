using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Damageable damageable;

    [SerializeField] float minSpeed = 1;
    [SerializeField] float maxSpeed = 2;

    [SerializeField] Sprite[] spritesByDamage;

    void Awake()
    {
        damageable.OnDamage += OnDamage;
    }

    void OnDestroy()
    {
        damageable.OnDamage -= OnDamage;
    }

    void OnValidate()
    {
        if(rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (damageable == null)
            damageable = GetComponent<Damageable>();
    }

    public void Setup(System.Random random)
    {
        float m = random.Range(minSpeed, maxSpeed);
        Vector2 dir = random.OnUnitCircle();
        rigidBody.linearVelocity = m * dir;
    }

    void OnDamage(float health, float maxHealth)    // Called from UnityEvent
    {
        float hpRate = 1 - (health / maxHealth);
        int index = (int)(hpRate * spritesByDamage.Length);
        index = Mathf.Min(index, spritesByDamage.Length - 1);

        spriteRenderer.sprite = spritesByDamage[index];
    }
}