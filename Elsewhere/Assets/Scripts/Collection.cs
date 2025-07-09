using UnityEngine;

public class Collection : MonoBehaviour
{
    //[SerializeField] AudioSource collectionAudio;
    public GameObject onCollectEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //collectionAudio.Play();
            this.gameObject.SetActive(false);
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
