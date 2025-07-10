using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int startingHealth = 3;
    public float currentHealth;

    [Header("Damage Cooldown")]
    [SerializeField] private float damageCooldown = 3f;
    private bool isInvincible = false;

    [Header("Damage Flash")]
    [SerializeField] private Renderer[] playerRenderers; // All 4 cube renderers
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashDuration = 0.2f;

    private Color[] originalColors;

    private void Start()
    {
        currentHealth = startingHealth;

        // Save original colors
        originalColors = new Color[playerRenderers.Length];
        for (int i = 0; i < playerRenderers.Length; i++)
        {
            originalColors[i] = playerRenderers[i].material.color;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (isInvincible) return;

        currentHealth -= damageAmount;
        Debug.Log("Player took damage. Remaining lives: " + currentHealth);

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityPeriod());
        }
    }

    private IEnumerator FlashRed()
    {
        foreach (Renderer rend in playerRenderers)
        {
            rend.material.color = damageColor;
        }

        yield return new WaitForSeconds(flashDuration);

        for (int i = 0; i < playerRenderers.Length; i++)
        {
            playerRenderers[i].material.color = originalColors[i];
        }
    }

    private IEnumerator InvincibilityPeriod()
    {
        isInvincible = true;
        yield return new WaitForSeconds(damageCooldown);
        isInvincible = false;
    }

    private void Die()
    {
        Debug.Log("Player died!");
        SceneManager.LoadScene(2);
    }
}
