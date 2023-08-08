using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pupuk : MonoBehaviour
{
    public int Pot;

    int state = 0;
    int timer = 0;

    int price;

    int priceDefaultPupukA = 50;

    int timerDefaultPupukA = 10;
    int timerStatePupuk1 = 10;
    int timerStatePupuk2 = 5;
    int timerStatePupuk3 = 1;
    int timerDefault;

    GameObject childImage;
    GameObject harvestButton;
    GameObject PupukChoices;
    bool PupukChoicesBool = false;
    GameObject PupukSprite;

    string occupier;
    Button PupukButton;

    // Start is called before the first frame update
    void Start()
    {

        //PlayerPrefs.SetInt("Gold",5000);
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        PupukSprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        PupukChoices = transform.parent.gameObject.transform.GetChild(5).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(4).gameObject;
        PupukButton = this.transform.parent.GetComponent<Button>();
        Debug.Log("PupukArray " + "Pupuk" + Pot);
        Debug.Log("Haskey " + PlayerPrefs.HasKey("State_Pupuk" + Pot));
        if (PlayerPrefs.HasKey("Pupuk"))
        {
            InvokeRepeating("Planting", 0f, 1f);
        }
    }

    public void Toogle()
    {
        if (!PupukChoicesBool)
        {
            PupukChoicesBool = true;
            PupukChoices.SetActive(true);
        }
        else
        {
            PupukChoicesBool = false;
            PupukChoices.SetActive(false);
        }
    }

    public void PlantPupukA()
    {
        occupier = "PupukA";
        timer = timerDefaultPupukA;
        price = priceDefaultPupukA;
        Buy();
    }

    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("Pupuk", occupier);
            PlayerPrefs.SetInt("Timer_Pupuk", timer);
            PlayerPrefs.SetInt("State_Pupuk", 1);
            PlayerPrefs.SetInt("Gold", gold - price);
            PlayerPrefs.Save();
            InvokeRepeating("Planting", 0f, 1f);
            PupukButton.interactable = false;
            PupukChoicesBool = false;
        }
        else
        {
            PupukChoicesBool = false;
            Debug.Log("Not Enough Gold");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State_Pupuk");
        timer = PlayerPrefs.GetInt("Timer_Pupuk");
        occupier = PlayerPrefs.GetString("Pupuk");
        Debug.Log("Occupier " + occupier);
        Debug.Log("Pupuk Progress Called. State " + state + " Timer " + timer);
        PupukSprite.GetComponent<Image>().enabled = true;

        if (occupier == "PupukA")
        {
            if (timer <= timerStatePupuk3)
            {
                PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/img_Botol_POC_6");
            }
            else if (timer <= timerStatePupuk2)
            {
                PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/img_Botol_POC_04");
            }
            else
            {
                PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("POC/gambar_/img_Botol_POC_01");
            }
        }

        timer--;
        PlayerPrefs.SetInt("State_Pupuk", state);
        PlayerPrefs.SetInt("Timer_Pupuk", timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            harvestButton.SetActive(true);
            CancelInvoke("Planting");
        }

        Debug.Log("Timer_Pupuk: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("Timer_Pupuk");
        PupukButton.interactable = true;
        if (timer <= 0)
        {
            Debug.Log("Timer_Pupuk State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "PupukA")
            {
                int lastPupukA = PlayerPrefs.GetInt("PupukA");
                PlayerPrefs.SetInt("PupukA", lastPupukA + 1); //increment inventory
            }

            harvestButton.SetActive(false);
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State_Pupuk: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("Pupuk");
        PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("POC/gambar_/img_Botol_POC_00");
        Debug.Log("Harvested " + occupier);
    }
}

 
