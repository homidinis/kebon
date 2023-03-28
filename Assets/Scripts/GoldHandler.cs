using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldHandler : MonoBehaviour
{
    public TextMeshProUGUI goldText; // The Text UI element to display the Gold

    private int gold; // The current Gold value

    void Start()
    {
         UpdateGoldDisplay(); // Update the Gold display
    }

    void Update()
    {

    }

    // Call this method to update the Gold display with the current Gold value
    public void UpdateGoldDisplay()
    {
        Debug.Log("test");
        goldText.text = "Gold: " + PlayerPrefs.GetInt("Gold"); // Update the Gold text
        Debug.Log("Updated gold! Gold: " + PlayerPrefs.GetInt("Gold"));
    }
}
