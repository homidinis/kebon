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
        Debug.Log("PlantingSpotArray " + "PlantingSpot2" + Pot);
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
        occupier = "Pupuk A";
        timer = timerDefaultPupukA;
        price = priceDefaultPupukA;
        Buy();
    }
  
    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("PlantingSpot2", occupier);
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

        if (occupier == "Pupuk A")
        {
            if (timer <= timerStatePupuk3)
            {
                PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pupuk_3");
            }
            else if (timer <= timerStatePupuk2)
            {
                PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pupuk_2");
            }
            else
            {
                PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pupuk_1");
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
            if (occupier == "Pupuk A")
            {
                int lastPupukA = PlayerPrefs.GetInt("Pupuk A");
                PlayerPrefs.SetInt("Pupuk A", lastPupukA + 1); //increment inventory
            }
            
            harvestButton.SetActive(false);
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State_Pupuk: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("Pupuk");
        PupukSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/placeholder");
        Debug.Log("Harvested " + occupier);
    }

    //public void Planting()
    //{

    //    //int state = 0;
    //    //int timer = timerDefault;

    //    //string plantingSpot = PotArray[Pot];

    //    //if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
    //    //{
    //    //    Debug.Log("Already planted here. State: " + state);
    //    //    Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier + " dengan state: " + state);
    //    //}
    //    //else
    //    //{
    //    //    int gold = PlayerPrefs.GetInt("Gold");

    //    //    if (gold > 50) 
    //    //    {
    //    //        PlayerPrefs.SetString(plantingSpot, occupier); //pot-sekian udah ada Pupuknya
    //    //        state++;
    //    //        PlayerPrefs.SetInt(StateArray[Pot], state); //state = 1 state gamau increment?
    //    //        PlayerPrefs.SetInt(TimerArray[Pot], timerDefault);

    //    //        PlayerPrefs.Save();
    //    //        Debug.Log("Started planting with state: " + state + " Timer: " + timer);

    //    //        if (state == 1)
    //    //        {
    //    //            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Pupuk_1");
    //    //            InvokeRepeating("PlantProgress", 0f, 1f);
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.Log("Not enough money. State: " + state + "Uang sekarang: " + PlayerPrefs.GetInt("Gold"));
    //    //        // TextMeshPro tmp_text = GetComponent<TextMeshPro>();
    //    //        // tmp_text.enabled = true;
    //    //        // tmp_text.CrossFadeAlpha(0.0f, 0.05f, false);
    //    //        // tmp_text.enabled = false;
    //    //    }
    //    //}
    //}


    //public void ClickHandler()
    //{
    //    string plantingSpot = "PlantingSpot2" + Pot;
    //    state = PlayerPrefs.GetInt("State_Pupuk" + Pot);
    //    timer = PlayerPrefs.GetInt("Timer_Pupuk" + Pot);


    //    if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == false)
    //    {
    //        Planting();
    //        Debug.Log("Planting function ran. State: " + state + "Planting at PotArray no. : " + Pot);
    //        string occupier = PlayerPrefs.GetString(plantingSpot);
    //        Debug.Log("Di pot " + plantingSpot + " sekarang udah ada: " + occupier);

    //    }

    //    else if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == true)
    //    {
    //        Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot));
    //    }

    //    else if (state == 3)
    //    {
    //        Harvest();
    //        Debug.Log("Harvested! State: " + state);
    //    }

    //    else
    //    {
    //        Debug.Log("bruh. State: " + state);
    //        Debug.Log("State_Kebun: " + state + "Planting at: " + plantingSpot);
    //        string occupier = PlayerPrefs.GetString(plantingSpot);
    //        Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier);
    //    }

    //}

}

//int lastGold = PlayerPrefs.GetInt("Gold");
//PlayerPrefs.SetInt("Gold", lastGold+20); //<- dapet gold saat menjual, pindah ke Rumah nanti
//PlayerPrefs.Save(); call this on scene exit

