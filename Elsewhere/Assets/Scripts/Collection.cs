using UnityEngine;

public class Collection : MonoBehaviour
{
    [SerializeField] private AudioClip collectionClip;
    [SerializeField] private GameObject onCollectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectionClip, transform.position);

            UIManager.Instance.AddCrystal();

            Instantiate(onCollectEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
