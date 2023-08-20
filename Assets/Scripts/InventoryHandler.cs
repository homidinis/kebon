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
    public TextMeshProUGUI PokchoiSiramJamurText;
    public TextMeshProUGUI PokchoiSausTiramText;
    public TextMeshProUGUI TumisPokchoiTahuText;
    public TextMeshProUGUI TumisSeladaJamurText;
    public TextMeshProUGUI TelurDadarSeladaText;
    public TextMeshProUGUI KangkungTempeText;
    public TextMeshProUGUI CahKangkungText;
    public TextMeshProUGUI JagungBakarText;
    public TextMeshProUGUI TumisJagungBakarText;
    public TextMeshProUGUI JagungJamurAsamManisText;
    public TextMeshProUGUI SupJagungText;
    public TextMeshProUGUI CincinBawangText;
    public TextMeshProUGUI TumisEdamameText;
    public TextMeshProUGUI EdamameGorengText;
    public TextMeshProUGUI NasiGorengEdamameText;
    public TextMeshProUGUI NasiGorengJagungText;
    public TextMeshProUGUI TelurRebusText;
    public TextMeshProUGUI TelurCeplokText;
    public TextMeshProUGUI TelurDadarText;
    public TextMeshProUGUI NasiGorengLengkapText;
    public TextMeshProUGUI PupukAText;

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
        JagungText.text = "" + PlayerPrefs.GetInt("Jagung");
        BawangText.text = "" + PlayerPrefs.GetInt("Bawang");
        EdamameText.text = "" + PlayerPrefs.GetInt("Edamame");
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
        PokchoiSiramJamurText.text = "" + PlayerPrefs.GetInt("Pokchoi Siram Jamur");
        PokchoiSausTiramText.text = "" + PlayerPrefs.GetInt("Pokchoi Saus Tiram");
        TumisPokchoiTahuText.text = "" + PlayerPrefs.GetInt("Tumis Pokchoi Tahu");
        TumisSeladaJamurText.text = "" + PlayerPrefs.GetInt("Tumis Selada Jamur");
        TelurDadarSeladaText.text = "" + PlayerPrefs.GetInt("Telur Dadar Selada");
        KangkungTempeText.text = "" + PlayerPrefs.GetInt("Kangkung Tempe");
        CahKangkungText.text = "" + PlayerPrefs.GetInt("Cah Kangkung");
        JagungBakarText.text = "" + PlayerPrefs.GetInt("Jagung Bakar");
        TumisJagungBakarText.text = "" + PlayerPrefs.GetInt("Tumis Jagung Bakar");
        JagungJamurAsamManisText.text = "" + PlayerPrefs.GetInt("Jagung Jamur Asam Manis");
        SupJagungText.text = "" + PlayerPrefs.GetInt("Sup Jagung");
        CincinBawangText.text = "" + PlayerPrefs.GetInt("Cincin Bawang");
        TumisEdamameText.text = "" + PlayerPrefs.GetInt("Tumis Edamame");
        EdamameGorengText.text = "" + PlayerPrefs.GetInt("Edamame Goreng");
        NasiGorengEdamameText.text = "" + PlayerPrefs.GetInt("NasiGoreng Edamame");
        NasiGorengJagungText.text = "" + PlayerPrefs.GetInt("NasiGoreng Jagung");
        TelurRebusText.text = "" + PlayerPrefs.GetInt("Telur Rebus");
        TelurCeplokText.text = "" + PlayerPrefs.GetInt("Telur Ceplok");
        TelurDadarText.text = "" + PlayerPrefs.GetInt("Telur Dadar");
        NasiGorengLengkapText.text = "" + PlayerPrefs.GetInt("Nasi Goreng Lengkap");
        PupukAText.text = "" + PlayerPrefs.GetInt("PupukA");
    }
}
