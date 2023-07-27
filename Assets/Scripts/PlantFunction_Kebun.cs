using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantFunction_Kebun : MonoBehaviour
{
    public int Pot;

    int state = 0;
    int timer = 0;

    int price;

    int priceDefaultJagung = 50;
    int priceDefaultBawang = 100;
    int priceDefaultEdamame = 150;

    int timerDefaultJagung = 10;
        int timerStateJagung1 = 10;
        int timerStateJagung2 = 5;
        int timerStateJagung3 = 1;

    int timerDefaultBawang = 10;
        int timerStateBawang1 = 10;
        int timerStateBawang2 = 5;
        int timerStateBawang3 = 1;

    int timerDefaultEdamame = 10;
        int timerStateEdamame1 = 10;
        int timerStateEdamame2 = 5;
        int timerStateEdamame3 = 1;

    int timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject PlantspotChoices;
    bool PlantspotChoicesBool = false;
    GameObject PlantspotSprite;

    string occupier;
    Button Plantspot;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Gold",5000);
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        PlantspotSprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        PlantspotChoices = transform.parent.gameObject.transform.GetChild(5).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(4).gameObject;                        
        Plantspot = this.transform.parent.GetComponent<Button>();
        Debug.Log("PlantingSpotArray " + "PlantingSpot" + Pot);
        Debug.Log("Haskey " + PlayerPrefs.HasKey("State_Kebun" + Pot));
        if (PlayerPrefs.HasKey("PlantingSpot"+Pot))
        {
            InvokeRepeating("Planting", 0f, 1f);
        }
    }

    public void Toogle()
    {
        if (!PlantspotChoicesBool)
        {
            PlantspotChoicesBool = true;
            PlantspotChoices.SetActive(true);
        }
        else
        {
            PlantspotChoicesBool = false;
            PlantspotChoices.SetActive(false);
        }
    }

    public void PlantJagung()
    {
        occupier = "Jagung";
        timer = timerDefaultJagung;
        price = priceDefaultJagung;
        Debug.Log("Bought Jagung");
        Buy();
    }
    public void PlantBawang()
    {
        occupier = "Bawang";
        timer = timerDefaultBawang;
        price = priceDefaultBawang;
        
        Buy();
    }
    public void PlantEdamame()
    {
        occupier = "Edamame"; //set Edamame here jadi kode dibawah tau kalau occupier sudah jadi Edamame 
        timer = timerDefaultEdamame;
        price = priceDefaultEdamame;
        
        Buy();
    }

    public void ClickHandler()
    {
        string plantingSpot = "PlantingSpot"+Pot;
        state = PlayerPrefs.GetInt("State_Kebun"+Pot);
        timer = PlayerPrefs.GetInt("Timer_Kebun"+Pot);


        if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == false)
        {
            Planting();
            
            Debug.Log("Planting function ran. State: " + state + "Planting at PotArray no. : " + Pot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            Debug.Log("Di pot " + plantingSpot + " sekarang udah ada: " + occupier);

        }

        else if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == true)
        {
            Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot));
        }

        else if (state == 3)
        {
            Harvest();
            Debug.Log("Harvested! State: " + state);
        }

        else
        {
            Debug.Log("bruh. State: " + state);
            Debug.Log("State_Kebun: " + state + "Planting at: " + plantingSpot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier);
        }

    }

    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("PlantingSpot"+Pot, occupier);
            PlayerPrefs.SetInt("Timer_Kebun"+Pot, timer);
            PlayerPrefs.SetInt("State_Kebun"+Pot, 1);
            PlayerPrefs.SetInt("Gold", gold - price);
            PlayerPrefs.Save();
            InvokeRepeating("Planting", 0f, 1f);
            Plantspot.interactable = false;
            PlantspotChoicesBool = false;
        }
        else
        {
            PlantspotChoicesBool = false;
            Debug.Log("Not Enugh Gold");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State_Kebun"+Pot);
        timer = PlayerPrefs.GetInt("Timer_Kebun"+Pot);
        occupier = PlayerPrefs.GetString("PlantingSpot"+Pot);
        Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        PlantspotSprite.GetComponent<Image>().enabled = true;

        if (occupier == "Jagung")
        {
            if (timer <= timerStateJagung3)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Jagung_3");
            }
            else if (timer <= timerStateJagung2)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Jagung_2");
            }
            else
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Jagung_1");
            }
        }
        else if(occupier == "Bawang") //correct spelling?
        {
            if (timer <= timerStateBawang3)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/bawang_3");
            }
            else if (timer <= timerStateBawang2)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/bawang_2");
            }
            else
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/bawang_1");
            }
        }
        else if(occupier == "Edamame")
        {
            if (timer <= timerStateEdamame3)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Edamame_3");
            }
            else if (timer <= timerStateEdamame2)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Edamame_2");
            }
            else
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Edamame_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State_Kebun"+Pot, state);
        PlayerPrefs.SetInt("Timer_Kebun"+Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            harvestButton.SetActive(true);
            CancelInvoke("Planting");
        }

        Debug.Log("Timer_Kebun: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("Timer_Kebun"+Pot);
        Plantspot.interactable = true;
        if (timer <= 0)
        {
            Debug.Log("Timer_Kebun State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Jagung")
            {
                int lastJagung = PlayerPrefs.GetInt("Jagung");
                PlayerPrefs.SetInt("Jagung", lastJagung + 1); //increment inventory
            }
            if (occupier == "Bawang")
            {
                int lastBawang = PlayerPrefs.GetInt("Bawang");
                PlayerPrefs.SetInt("Bawang", lastBawang + 1); //increment inventory
            }
            if (occupier == "Edamame")
            {
                int lastEdamame = PlayerPrefs.GetInt("Edamame");
                PlayerPrefs.SetInt("Edamame", lastEdamame + 1); //increment inventory
            }
            harvestButton.SetActive(false);
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State_Kebun: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("PlantingSpot"+Pot);
        PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/placeholder");
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
    //    //        PlayerPrefs.SetString(plantingSpot, occupier); //pot-sekian udah ada Jagungnya
    //    //        state++;
    //    //        PlayerPrefs.SetInt(StateArray[Pot], state); //state = 1 state gamau increment?
    //    //        PlayerPrefs.SetInt(TimerArray[Pot], timerDefault);

    //    //        PlayerPrefs.Save();
    //    //        Debug.Log("Started planting with state: " + state + " Timer: " + timer);

    //    //        if (state == 1)
    //    //        {
    //    //            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Jagung_1");
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


}

//int lastGold = PlayerPrefs.GetInt("Gold");
//PlayerPrefs.SetInt("Gold", lastGold+20); //<- dapet gold saat menjual, pindah ke Rumah nanti
//PlayerPrefs.Save(); call this on scene exit

