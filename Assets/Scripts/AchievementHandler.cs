using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AchievementHandler : MonoBehaviour
{
    public GameObject[] Menu;
    public string[] namaMenu =
    {
        "Pokchoi Siram Jamur",
        "Pokchoi Saus Tiram",
        "Tumis Pokchoi Tahu",
        "Tumis Selada Jamur",
        "Telur Dadar Selada",
        "Kangkung Tempe",
        "Cah Kangkung",
        "Jagung Bakar",
        "Tumis Jagung Bakar",
        "Jagung Jamur Asam Manis",
        "Sup Jagung",
        "Cincin Bawang",
        "Tumis Edamame",
        "Edamame Goreng",
        "Nasi Goreng Edamame",
        "Nasi Goreng Jagung",
        "Telur Rebus",
        "Telur Ceplok",
        "Telur Dadar",
        "Nasi Goreng Lengkap"
    };
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < namaMenu.Length; i++)
        {
            if (PlayerPrefs.HasKey(namaMenu[i]))
            {
                TextMeshProUGUI menuText = Menu[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                menuText.text = namaMenu[i];
                Image menuImg = Menu[i].transform.GetChild(1).GetComponent<Image>();
                menuImg.color = Color.white;
            }
            else
            {
                TextMeshProUGUI menuText = Menu[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                menuText.text = "???";
                Image menuImg = Menu[i].transform.GetChild(1).GetComponent<Image>();
                menuImg.color = Color.black;
            }
        }
    }
}
