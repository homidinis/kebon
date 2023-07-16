using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Masak : MonoBehaviour
{
    


    public GameObject btnObject;
    public GameObject canvasObject;
    public GameObject recipePanel;
    public GameObject recipeIngredientsPanel;
    public GameObject masakButton;
    public TextMeshProUGUI recipeTitle;
    public TextMeshProUGUI recipeDescription;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Susu"));
        Debug.Log("Get Length 1: " + GlobalVariable.arrayMasak.GetLength(1) + " Get Length 0: " + GlobalVariable.arrayMasak.GetLength(0));
        for (int i = 0; i < GlobalVariable.arrayMasak.GetLength(0); i++)
        {
            GameObject myObj = Instantiate(btnObject, new Vector2(0, 0), Quaternion.identity);
            
            Button myObjButton = myObj.GetComponent<Button>();

            int iCopy = i;
            myObjButton.onClick.AddListener(() => OpenRecipe(iCopy));

            myObj.transform.parent = canvasObject.transform;
            myObj.transform.localScale = new Vector3(1, 1, 1);

            //myObjButton.onClick.AddListener(delegate { Buy(i); });

            TextMeshProUGUI myObjNameText = myObj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            myObjNameText.text = GlobalVariable.arrayMasak[i, 0];

            Image myObjImage = myObj.transform.Find("Image").GetComponent<Image>();
            myObjImage.sprite = Resources.Load<Sprite>(GlobalVariable.arrayMasak[i, 1]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OpenRecipe(int j)
    {
        recipePanel.SetActive(false);
        recipeIngredientsPanel.SetActive(true);
        recipeTitle.text = GlobalVariable.arrayMasak[j, 0];
        recipeDescription.text = GlobalVariable.arrayMasak[j, 2];
        Button myMasakButton = masakButton.GetComponent<Button>();
        myMasakButton.onClick.RemoveAllListeners();
        myMasakButton.onClick.AddListener(() => MasakFunction(j));
    }
    void MasakFunction(int i)
    {
        Debug.Log(GlobalVariable.jaggedArray[i].Length);
        bool readyToCook = true;
        for(int j = 0; j < GlobalVariable.jaggedArray[i].Length; j++)
        {
            int bahan = PlayerPrefs.GetInt(GlobalVariable.jaggedArray[i][j]);
            if(bahan <= 0)
            {
                readyToCook = false;
            }
        }
        if(readyToCook)
        {
            for(int j = 0; j < GlobalVariable.jaggedArray[i].Length; j++)
            {
                int bahan = PlayerPrefs.GetInt(GlobalVariable.jaggedArray[i][j]);
                bahan--;
                PlayerPrefs.SetInt(GlobalVariable.jaggedArray[i][j], bahan);
                //open cooking animation
                int jumlahMakanan = PlayerPrefs.GetInt(GlobalVariable.arrayMasak[i, 0]);
                jumlahMakanan++;
                PlayerPrefs.SetInt(GlobalVariable.arrayMasak[i, 0], jumlahMakanan);
                Debug.Log(GlobalVariable.arrayMasak[i, 0] + ' ' + jumlahMakanan);
            
            }
        } else
        {
            Debug.Log("Bahan kurang");
        }
    }
    void Buy(int j) //onclick: check gold: if price < gold then increment inventory. add "yakin membeli" button
    {
        int price = int.Parse(GlobalVariable.arrayMasak[j, 2]);
        string name = GlobalVariable.arrayMasak[j, 0];
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
