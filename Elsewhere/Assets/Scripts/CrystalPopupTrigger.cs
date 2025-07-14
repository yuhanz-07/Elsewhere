using UnityEngine;

public class CrystalWithPopup : MonoBehaviour
{
    public GameObject popupText;

    private Transform cameraTransform;
    
    private void Start()
    {
        cameraTransform = Camera.main?.transform;

        if (popupText != null)
            popupText.SetActive(false);
    }

    private void LateUpdate()
    {
        if (popupText != null && popupText.activeSelf && cameraTransform != null)
        {
            popupText.transform.position = transform.position + Vector3.up * 2f;

            Vector3 flatDirection = cameraTransform.position - popupText.transform.position;
            flatDirection.y = 0;

            if (flatDirection.sqrMagnitude > 0.001f)
            {
                Quaternion rotation = Quaternion.LookRotation(-flatDirection);
                popupText.transform.rotation = rotation;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && popupText != null)
        {
            popupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && popupText != null)
        {
            popupText.SetActive(false);
        }
    }
}
