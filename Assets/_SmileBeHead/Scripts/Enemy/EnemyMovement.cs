using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    //simple pathfinding with obstacle detection 


    [Header("Obstacle Avoidance")]
    [SerializeField] private float obstacleDetectionDistance = 0.5f;
    [SerializeField] private LayerMask obstacleLayerMask;

    private Rigidbody2D rb;
    private Transform target;
    private EnemyController enemyController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector2 moveDir = GetMoveDirection();

        rb.linearVelocity = moveDir * enemyController.EnemyData.moveSpeed;
        
    }

    private Vector2 GetMoveDirection()
    {
        Vector2 toTarget = (target.position - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, toTarget, obstacleDetectionDistance ,obstacleLayerMask);

        if (!hit)
        {
            return toTarget;
        }

        Vector2 left = RotateVector(toTarget, 45f);
        Vector2 right = RotateVector(toTarget, -45f);

        if (!Physics2D.Raycast(transform.position , left ,obstacleDetectionDistance, obstacleLayerMask))
        {
            return left;
        }
        if (!Physics2D.Raycast(transform.position , right ,obstacleDetectionDistance, obstacleLayerMask))
        {
            return right;
        }

        return Vector2.zero;
    }

    private Vector2 RotateVector(Vector2 vector, float angle)
    {
        //float rad = angle * Mathf.Deg2Rad;
        //float sin = Mathf.Sin(rad);
        //float cos = Mathf.Cos(rad);

        //return new Vector2(
        //    cos * vector.x - sin * vector.y,
        //    sin * vector.x + cos * vector.y
        //    ).normalized;

        Quaternion rotation = Quaternion.Euler(0,0,angle);
        return (rotation * vector).normalized;
    }
}
