using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AchievementHandler : MonoBehaviour
{

    public GameObject PokchoiSiramJamur;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Pokchoi Siram Jamur"))
        {
            TextMeshProUGUI pokchoiSiramJamurText =  PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Pokchoi Siram Jamur";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color= Color.white;
        }
        if (PlayerPrefs.HasKey("Pokchoi Saus Tiram"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Pokchoi Saus Tiram";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Tumis Pokchoi Tahu"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Tumis Pokchoi Tahu";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Tumis Selada Jamur"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Tumis Selada Jamur";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Telur Dadar Selada"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Telur Dadar Selada";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Kangkung Tempe"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Kangkung Tempe";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Cah Kangkung"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Cah Kangkung";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Jagung Bakar"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Jagung Bakar";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Tumis Jagung Bakar"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Tumis Jagung Bakar";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Jagung Jamur Asam Manis"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Jagung Jamur Asam Manis";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Sup Jagung"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Sup Jagung";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Cincin Bawang"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Cincin Bawang";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Tumis Edamame"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Tumis Edamame";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Edamame Goreng"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Edamame Goreng";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Nasi Goreng Edamame"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Nasi Goreng Edamame";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Nasi Goreng Jagung"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Nasi Goreng Jagung";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Telur Rebus"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Telur Rebus";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Telur Ceplok"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Telur Ceplok";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Telur Dadar"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Telur Dadar";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }
        if (PlayerPrefs.HasKey("Nasi Goreng Lengkap"))
        {
            TextMeshProUGUI pokchoiSiramJamurText = PokchoiSiramJamur.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pokchoiSiramJamurText.text = "Nasi Goreng Lengkap";
            Image pokchoiSiramJamurImg = PokchoiSiramJamur.transform.GetChild(1).GetComponent<Image>();
            pokchoiSiramJamurImg.color = Color.white;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
