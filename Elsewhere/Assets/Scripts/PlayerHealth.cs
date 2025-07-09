using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth = 3;
    public float currentHealth { get; private set; }
    private bool invulnerable = false;

    [Header("Invulnerability")]
    [SerializeField] private float iFramesDuration = 1f;
    [SerializeField] private int numberOfFlashes = 4;
    [SerializeField] private Renderer playerRenderer;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        Debug.Log("Player took damage! Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died!");
            gameObject.SetActive(false); // Or trigger death logic
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics.IgnoreLayerCollision(9, 10, true); // Make sure Player is Layer 9, Enemy is Layer 10

        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (playerRenderer != null)
                playerRenderer.material.color = Color.red;

            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));

            if (playerRenderer != null)
                playerRenderer.material.color = Color.white;

            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

        Physics.IgnoreLayerCollision(9, 10, false);
        invulnerable = false;
    }
}
