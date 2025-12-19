using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float damage;
    private Vector2 direction;

    [SerializeField] private float lifeTime = 2f;

    public void Initialize(Vector2 dir, float bulletSpeed, float bulletDamage)
    {
        //direction = dir.normalized;
        speed = bulletSpeed;
        damage = bulletDamage;

        Invoke(nameof(DestroySelf), lifeTime);
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
