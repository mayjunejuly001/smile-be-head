using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }

    private void UpdateHealthBar(float healthPercent)
    {
        fillImage.fillAmount = healthPercent;
    }
}
