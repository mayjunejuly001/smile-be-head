using UnityEngine;
using System; 

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    public EnemyData EnemyData => enemyData;

    public static event Action<EnemyController> OnEnemyKilled;

    private EnemyHealth enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.Initialize(enemyData.maxHealth);
        enemyHealth.OnDeath += HandleDeath;

    }

    private void HandleDeath()
    {
       OnEnemyKilled?.Invoke(this);
       Destroy(gameObject);
    }

}
