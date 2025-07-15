using UnityEngine;

public class SpriteWithPrompt : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pressEText;
    public GameObject spriteToShow;

    private bool playerInRange = false;

    private void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false);

        if (spriteToShow != null)
            spriteToShow.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && spriteToShow != null)
            {
                spriteToShow.SetActive(true);
                pressEText.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pressEText != null)
        {
            pressEText.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pressEText != null)
                pressEText.SetActive(false);

            if (spriteToShow != null)
                spriteToShow.SetActive(false);

            playerInRange = false;
        }
    }
}
