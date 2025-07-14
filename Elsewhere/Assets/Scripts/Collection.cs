using UnityEngine;

public class Collection : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject onCollectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            Destroy(gameObject);


            UIManager.Instance.AddCrystal();

            if (onCollectEffect != null)
                Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
