using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryHandler : MonoBehaviour
{
    public TextMeshProUGUI kangkungText;
    public TextMeshProUGUI seladaText;
    public TextMeshProUGUI pokchoiText;
    public TextMeshProUGUI JagungText;
    public TextMeshProUGUI BawangText;
    public TextMeshProUGUI EdamameText;
    public TextMeshProUGUI TelurText;
    public TextMeshProUGUI JamurText;
    public TextMeshProUGUI KecapText;
    public TextMeshProUGUI SausTiramText;
    public TextMeshProUGUI TahuText;
    public TextMeshProUGUI TempeText;
    public TextMeshProUGUI CabaiText;
    public TextMeshProUGUI MargarinText;
    public TextMeshProUGUI TepungText;
    public TextMeshProUGUI MinyakText;
    public TextMeshProUGUI JambuText;
    public TextMeshProUGUI LengkengText;
    public TextMeshProUGUI PepayaText;
    public TextMeshProUGUI RambutanText;
    public TextMeshProUGUI PisangText;
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
        pokchoiText.text = "" + PlayerPrefs.GetInt("Pokchoi")
        JagungText.text = "" + PlayerPrefs.GetInt("Kangkung");
        BawangText.text = "" + PlayerPrefs.GetInt("Selada");
        EdamameText.text = "" + PlayerPrefs.GetInt("Pokchoi");
        JambuText.text = "" + PlayerPrefs.GetInt("Jambu");
        LengkengText.text = "" + PlayerPrefs.GetInt("Lengkeng");
        PepayaText.text = "" + PlayerPrefs.GetInt("Pepaya");
        RambutanText.text = "" + PlayerPrefs.GetInt("Rambutan");
        PisangText.text = "" + PlayerPrefs.GetInt("Pisang");
        TelurText.text = "" + PlayerPrefs.GetInt("Telur");
        JamurText.text = "" + PlayerPrefs.GetInt("Jamur");
        KecapText.text = "" + PlayerPrefs.GetInt("Kecap");
        SausTiramText.text = "" + PlayerPrefs.GetInt("SausTiram");
        TahuText.text = "" + PlayerPrefs.GetInt("Tahu");
        TempeText.text = "" + PlayerPrefs.GetInt("Tempe");
        CabaiText.text = "" + PlayerPrefs.GetInt("Cabai");
        MargarinText.text = "" + PlayerPrefs.GetInt("Margarin");
        TepungText.text = "" + PlayerPrefs.GetInt("Tepung");
        MinyakText.text = "" + PlayerPrefs.GetInt("Minyak");

    }
}
