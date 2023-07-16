using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryHandler : MonoBehaviour
{
    public TextMeshProUGUI kangkungText;
    public TextMeshProUGUI seladaText;
    public TextMeshProUGUI pokchoiText;

    private int gold; // The current score value

    void Start()
    {
        UpdateScoreDisplay(); // Update the score display
    }

    void Update()
    {
        UpdateScoreDisplay();
    }

    // Call this method to update the score display with the current score value
    void UpdateScoreDisplay()
    {
        kangkungText.text = "" + PlayerPrefs.GetInt("Kangkung");
        seladaText.text = "" + PlayerPrefs.GetInt("Selada");
        pokchoiText.text = "" + PlayerPrefs.GetInt("Pokchoi");

    }
}
