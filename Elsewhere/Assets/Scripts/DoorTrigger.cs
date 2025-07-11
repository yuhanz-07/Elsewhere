using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (UIManager.Instance != null && UIManager.Instance.HasAllCrystals())
            {
                Debug.Log("All crystals collected. Loading next scene...");

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                SceneManager.LoadScene(3);
            }
            else
            {
                MessageDisplay.Instance.ShowMessage("You need all 5 crystals to open the door!");
            }
        }
    }
}
