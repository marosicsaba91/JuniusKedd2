using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; } = 100;
    [SerializeField] Behaviour[] disableWhenDie;

    public event Action<float, float> OnDamage;

    float currentHeath;

    void Start()
    {
        currentHeath = MaxHealth;
    }

    public float CurrentHealth
    {
        get => currentHeath;
        set
        {
            if (currentHeath == value)
                return;

            currentHeath = value;
            OnHealthChanged();
        }
    }

    public void Damage(float damage)
    {
        currentHeath -= damage;
        OnHealthChanged();
    }

    void OnHealthChanged()
    {
        currentHeath = Mathf.Clamp(currentHeath, 0, MaxHealth);

        OnDamage?.Invoke(currentHeath, MaxHealth);

        if (currentHeath <= 0)
        {
            foreach (Behaviour b in disableWhenDie)
                b.enabled = false;
        }
    }
}
