using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market : MonoBehaviour
{
    string[,] arrayMarket =
    { // 1 ke kanan, 0 ke bawah
        { "Susu", "Sprites/Kangkung_2", "50" }, 
        { "Ayam", "Sprites/Kangkung_1", "100" },
        { "Mentega", "Sprites/Kangkung_2", "20" },
        { "SusuB", "Sprites/Kangkung_2", "50" },
        { "AyamB", "Sprites/Kangkung_1", "100" },
        { "MentegaB", "Sprites/Kangkung_2", "20" },
        { "Susuc", "Sprites/Kangkung_2", "50" },
        { "Ayamc", "Sprites/Kangkung_1", "100" },
        { "Mentegac", "Sprites/Kangkung_2", "20" }
    };

    public GameObject btnObject;
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Susu"));
        Debug.Log("Get Length 1: " + arrayMarket.GetLength(1) + " Get Length 0: " + arrayMarket.GetLength(0));
        for(int i = 0; i < arrayMarket.GetLength(0); i++) 
        {
            GameObject myObj = Instantiate(btnObject, new Vector2(0,0), Quaternion.identity);

            Button myObjButton = myObj.GetComponent<Button>();
            int iCopy = i;
            myObjButton.onClick.AddListener(() => Buy(iCopy));

            myObj.transform.parent = canvasObject.transform;
            myObj.transform.localScale = new Vector3(1, 1, 1);

            //myObjButton.onClick.AddListener(delegate { Buy(i); });

            TextMeshProUGUI myObjNameText = myObj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            myObjNameText.text = arrayMarket[i,0];

            TextMeshProUGUI myObjPriceText = myObj.transform.Find("Price").GetComponent<TMPro.TextMeshProUGUI>();
            myObjPriceText.text = arrayMarket[i, 2];

            Image myObjImage = myObj.transform.Find("Image").GetComponent<Image>();
            myObjImage.sprite = Resources.Load<Sprite>(arrayMarket[i, 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Buy(int j) //onclick: check gold: if price < gold then increment inventory. add "yakin membeli" button
    {
        int price = int.Parse(arrayMarket[j, 2]);
        string name = arrayMarket[j, 0];
        int Gold = PlayerPrefs.GetInt("Gold");
        if(Gold >= price)
        {
            Gold -= price;
            int totalItem = PlayerPrefs.GetInt(name);
            totalItem++;

            PlayerPrefs.SetInt("Gold", Gold);
            PlayerPrefs.SetInt(name, totalItem);
            PlayerPrefs.Save();
            Debug.Log("Bought");
        }
        else
        {
            Debug.Log("Gold Tidak Cukup");
        }
    }
}
