using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable
{
   public event Action OnDeath;

   private float currentHealth;

   public void Initialize(float maxHealth)
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
           OnDeath?.Invoke();
        }
    }
}
