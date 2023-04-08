using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldHandler : MonoBehaviour
{
    public TextMeshProUGUI goldText; // The Text UI element to display the score

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
        goldText.text = "Gold: " + PlayerPrefs.GetInt("Gold"); // Update the score text
    }
}
