using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Identity")]
    public EnemyType enemyType;

    [Header("Stats")]
    public float maxHealth = 3f;
    public float moveSpeed = 2f;
    public float damage = 1f;

    [Header("Behavior")]
    public float stoppingDistance = 0.1f;
    public float contactDamageInterval = 0.5f;

}
