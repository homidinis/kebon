using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldHandler : MonoBehaviour
{
    public TextMeshProUGUI goldText; // The Text UI element to display the score

    private int gold; // The current score value

    void Start()
    {
<<<<<<< Updated upstream
        PlayerPrefs.SetInt("Gold",500);
         UpdateGoldDisplay(); // Update the Gold display
=======
        UpdateScoreDisplay(); // Update the score display
>>>>>>> Stashed changes
    }

    void Update()
    {
        UpdateScoreDisplay();
    }

    // Call this method to update the score display with the current score value
    void UpdateScoreDisplay()
    {
<<<<<<< Updated upstream
        goldText.text = "Gold: " + PlayerPrefs.GetInt("Gold"); // Update the Gold text
        Debug.Log("Updated gold! Gold: " + PlayerPrefs.GetInt("Gold"));
=======
        goldText.text = "Gold: " + PlayerPrefs.GetInt("Gold"); // Update the score text
>>>>>>> Stashed changes
    }
}
