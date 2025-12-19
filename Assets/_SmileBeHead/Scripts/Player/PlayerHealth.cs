using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour , IDamageable
{
    [SerializeField] private float maxHealth = 5f;

    public event Action<float> OnHealthChanged;
    public event Action OnPlayerDeath;

    private float currenthealth;


    private void Awake()
    {
        currenthealth = maxHealth;
        OnHealthChanged?.Invoke(1f);
    }

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
        Debug.Log(currenthealth);

        OnHealthChanged?.Invoke(currenthealth / maxHealth);

        if (currenthealth <= 0f )
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
