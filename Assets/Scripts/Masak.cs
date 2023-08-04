using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Masak : MonoBehaviour
{
    public Animator anim;
    public GameObject btnObject;
    public GameObject canvasObject;
    public GameObject recipePanel;
    public GameObject recipeIngredientsPanel;
    public GameObject masakButton;
    public TextMeshProUGUI recipeTitle;
    public TextMeshProUGUI recipeDescription;
    //public GameObject recipeImage;
    // Start is called before the first frame update
    void Start()    
    {
        //PlayerPrefs.SetInt("Jagung",1);
        //PlayerPrefs.SetInt("Margarin",1);
        Debug.Log("Get Length 1: " + GlobalVariable.arrayResep.GetLength(1) + " Get Length 0: " + GlobalVariable.arrayResep.GetLength(0));
        Debug.Log(GlobalVariable.arrayResep.GetLength(0));
        for (int i = 0; i < GlobalVariable.arrayResep.GetLength(0); i++)
        {
            GameObject myObj = Instantiate(btnObject, new Vector2(0, 0), Quaternion.identity);
            
            Button myObjButton = myObj.GetComponent<Button>();

            int iCopy = i;
            myObjButton.onClick.AddListener(() => OpenRecipe(iCopy));
            Debug.Log("Listener added " + iCopy);

            myObj.transform.parent = canvasObject.transform;
            myObj.transform.localScale = new Vector3(1, 1, 1);

            //myObjButton.onClick.AddListener(delegate { Buy(i); });/

            TextMeshProUGUI myObjNameText = myObj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            myObjNameText.text = GlobalVariable.arrayResep[i, 0];

            Image myObjImage = myObj.transform.Find("Image").GetComponent<Image>();
            myObjImage.sprite = Resources.Load<Sprite>(GlobalVariable.arrayResep[i, 1]);
            //PlayerPrefs.SetInt("Pokchoi", 0);
            //PlayerPrefs.SetInt("Bawang", 0);
            //PlayerPrefs.SetInt("Jamur", 0);
            //PlayerPrefs.SetInt("Kecap", 0);
        }
    }

    void OpenRecipe(int j)
    {
        recipePanel.SetActive(false);
        recipeIngredientsPanel.SetActive(true);
        recipeTitle.text = GlobalVariable.arrayResep[j, 0];
        recipeDescription.text = GlobalVariable.arrayResep[j, 2];
        //recipeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(GlobalVariable.arrayResep[j, 1]);
        Button myMasakButton = masakButton.GetComponent<Button>();
        myMasakButton.onClick.RemoveAllListeners();
        myMasakButton.onClick.AddListener(() => MasakFunction(j));
        Debug.Log("Recipe opened");
    }
    void MasakFunction(int i)
    {
        
        Debug.Log(GlobalVariable.arrayIngredient[i].Length);
        bool readyToCook = true;
        for(int j = 0; j < GlobalVariable.arrayIngredient[i].Length; j++)
        {
            int bahan = PlayerPrefs.GetInt(GlobalVariable.arrayIngredient[i][j]);
            string namaBahan = GlobalVariable.arrayIngredient[i][j];
            if (bahan <= 0)
            {
                readyToCook = false;
                Debug.Log("Bahan kurang!" + namaBahan + bahan);
            }
        }
        if(readyToCook)
        {
            for(int j = 0; j < GlobalVariable.arrayIngredient[i].Length; j++)
            {
                int bahan = PlayerPrefs.GetInt(GlobalVariable.arrayIngredient[i][j]); 
                bahan--;
                
                PlayerPrefs.SetInt(GlobalVariable.arrayIngredient[i][j], bahan); //reduce bahan by 1 and set playerpref of that ingredient
                anim.Play("animasiMasak");
                Debug.Log("Animation played");
                // plate = GameObject.Find("plate");
                //set plate as cooked food
                //activate plate in animation
                //open cooking animation
                int jumlahMakanan = PlayerPrefs.GetInt(GlobalVariable.arrayResep[i, 0]); //resep yang bahannya masakan lain bagaimana?
                jumlahMakanan++;
                PlayerPrefs.SetInt(GlobalVariable.arrayResep[i, 0], jumlahMakanan);
                Debug.Log(GlobalVariable.arrayResep[i, 0] + ' ' + jumlahMakanan);
            
            }
        } else
        {
            Debug.Log("Something went wrong: readytocook: " + readyToCook); ;
        }
    }
    void Buy(int j) //onclick: check gold: if price < gold then increment inventory. add "yakin membeli" button
    {
        int price = int.Parse(GlobalVariable.arrayResep[j, 2]);
        string name = GlobalVariable.arrayResep[j, 0];
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
