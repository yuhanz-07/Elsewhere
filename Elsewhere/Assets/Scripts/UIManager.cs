using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private int maxCrystals = 6;
    private int crystalCount = 0;

    [SerializeField] private TextMeshProUGUI crystalText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCrystal()
    {
        crystalCount++;
        crystalText.text = crystalCount + "/" + maxCrystals;
    }

    public bool HasAllCrystals()
    {
        return crystalCount >= maxCrystals;
    }
}
