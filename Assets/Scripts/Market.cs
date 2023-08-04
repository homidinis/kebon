using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market : MonoBehaviour
{

    public GameObject btnObject;
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Get Length 1: " + GlobalVariable.arrayMarket.GetLength(1) + " Get Length 0: " + GlobalVariable.arrayMarket.GetLength(0));
        for(int i = 0; i < GlobalVariable.arrayMarket.GetLength(0); i++) 
        {
            GameObject myObj = Instantiate(btnObject, new Vector2(0,0), Quaternion.identity);

            Button myObjButton = myObj.GetComponent<Button>();
            int iCopy = i;
            myObjButton.onClick.AddListener(() => Buy(iCopy));

            myObj.transform.parent = canvasObject.transform;
            myObj.transform.localScale = new Vector3(1, 1, 1);

            //myObjButton.onClick.AddListener(delegate { Buy(i); });

            TextMeshProUGUI myObjNameText = myObj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            myObjNameText.text = GlobalVariable.arrayMarket[i,0];

            TextMeshProUGUI myObjPriceText = myObj.transform.Find("Price").GetComponent<TMPro.TextMeshProUGUI>();
            myObjPriceText.text = GlobalVariable.arrayMarket[i, 2];

            Image myObjImage = myObj.transform.Find("Image").GetComponent<Image>();
            myObjImage.sprite = Resources.Load<Sprite>(GlobalVariable.arrayMarket[i, 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Buy(int j) //onclick: check gold: if price < gold then increment inventory. add "yakin membeli" button
    {
        int price = int.Parse(GlobalVariable.arrayMarket[j, 2]);
        string name = GlobalVariable.arrayMarket[j, 0];
        int Gold = PlayerPrefs.GetInt("Gold");
        if(Gold >= price)
        {
            Gold -= price;
            int totalItem = PlayerPrefs.GetInt(name);
            totalItem++;

            PlayerPrefs.SetInt("Gold", Gold);
            PlayerPrefs.SetInt(name, totalItem);
            PlayerPrefs.Save();
            Debug.Log("Bought " + name + " Total item: " + totalItem);
        }
        else
        {
            Debug.Log("Gold Tidak Cukup");
        }
    }
}
