using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyController controller;
    private Coroutine damageCoroutine;

    private void Awake()
    {
        controller = GetComponent<EnemyController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playeHealth = collision.collider.GetComponent<PlayerHealth>();
        if (playeHealth != null && damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(DealContinuousDamage(playeHealth));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<PlayerHealth>() != null)
        {
            StopDamage();
        }
    }

    private IEnumerator DealContinuousDamage(PlayerHealth player) {
        while (player != null)
        {
            player.TakeDamage(controller.EnemyData.damage);
            yield return new WaitForSeconds(controller.EnemyData.contactDamageInterval);
        }
        StopDamage();
    }

    private void StopDamage()
    {
        if(damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
}
