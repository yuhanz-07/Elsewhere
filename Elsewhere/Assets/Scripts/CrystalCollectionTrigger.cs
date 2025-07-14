using UnityEngine;

public class CrystalCollectionTrigger : MonoBehaviour
{
    public GameObject crystalRoot;

    public GameObject onCollectEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.AddCrystal();
            Instantiate(onCollectEffect, crystalRoot.transform.position, crystalRoot.transform.rotation);

            crystalRoot.SetActive(false);
        }
    }
}
