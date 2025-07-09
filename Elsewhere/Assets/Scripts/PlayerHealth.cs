using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int startingHealth = 3;
    public float currentHealth;


    [Header("Damage Cooldown")]
    [SerializeField] private float damageCooldown = 3f;
    private bool isInvincible = false;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isInvincible) return;

        currentHealth -= damageAmount;
        Debug.Log("Player took damage. Remaining lives: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityPeriod());
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
    }
}
