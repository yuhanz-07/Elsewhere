using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayClickSound()
    {
        if (audioSource != null && audioSource.enabled && audioSource.gameObject.activeInHierarchy)
        {
            audioSource.Play();
        }
    }
}
