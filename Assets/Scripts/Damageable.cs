using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] Behaviour[] disableWhenDie;

    float currentHeath;

    void Start()
    {
        currentHeath = maxHealth;
    }

    public void Damage(float damage) 
    {
        currentHeath -= damage;

        if (currentHeath <= 0)
        {
            foreach(Behaviour b in disableWhenDie)
                b.enabled = false;
        }
    }
}
