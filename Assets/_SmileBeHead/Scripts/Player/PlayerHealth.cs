using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour , IDamageable
{
    [SerializeField] private float maxHealth = 5f;

    public event Action OnPlayerDeath;

    private float currenthealth;


    private void Awake()
    {
        currenthealth = maxHealth;

    }

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
        Debug.Log(currenthealth);
        if (currenthealth <= 0f )
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
