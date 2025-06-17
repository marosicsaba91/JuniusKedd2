using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] GameObject inactivateWhenDie;
    [SerializeField] Behaviour disableWhenDie;

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
            disableWhenDie.enabled = false;
            inactivateWhenDie.SetActive(false);
        }
    }
}
