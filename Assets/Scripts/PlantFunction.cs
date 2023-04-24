using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantFunction : MonoBehaviour
{
    public int Pot;

    int state = 0;
    int timer = 0;

    int price;

    int priceDefaultKangkung = 50;
    int priceDefaultPokChoi = 100;
    int priceDefaultSelada = 150;

    int timerDefaultKangkung = 10;
        int timerStateKangkung1 = 10;
        int timerStateKangkung2 = 5;
        int timerStateKangkung3 = 1;

    int timerDefaultPokChoi = 10;
        int timerStatePokChoi1 = 10;
        int timerStatePokChoi2 = 5;
        int timerStatePokChoi3 = 1;

    int timerDefaultSelada = 10;
        int timerStateSelada1 = 10;
        int timerStateSelada2 = 5;
        int timerStateSelada3 = 1;

    int timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject NetPotChoices;
    bool netPotChoicesBool = false;

    string occupier;
    Button NetPot;

    // Start is called before the first frame update
    void Start()
    {
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        NetPotChoices = transform.parent.gameObject.transform.GetChild(3).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(2).gameObject;                        
        NetPot = this.transform.parent.GetComponent<Button>();
        Debug.Log("PotArray " + "Pot" + Pot);
        Debug.Log("Haskey " + PlayerPrefs.HasKey("State" + Pot));
        if (PlayerPrefs.HasKey("Pot"+Pot))
        {
            InvokeRepeating("Planting", 0f, 1f);
        }
    }

    public void Toogle()
    {
        if (!netPotChoicesBool)
        {
            netPotChoicesBool = true;
            NetPotChoices.SetActive(true);
        }
        else
        {
            netPotChoicesBool = false;
            NetPotChoices.SetActive(false);
        }
    }
    public void PlantKangkung()
    {
        occupier = "Kangkung";
        timer = timerDefaultKangkung;
        price = priceDefaultKangkung;
        //ClickHandler();
        Buy();
    }
    public void PlantPokchoi()
    {
        occupier = "Pokchoi";
        timer = timerDefaultPokChoi;
        price = priceDefaultPokChoi;
        //ClickHandler();
        Buy();
    }
    public void PlantSelada()
    {
        occupier = "Selada"; //set selada here jadi kode dibawah tau kalau occupier sudah jadi selada 
        timer = timerDefaultSelada;
        price = priceDefaultSelada;
        //ClickHandler();
        Buy();
    }

    public void ClickHandler()
    {
        string plantingSpot = "Pot"+Pot;
        state = PlayerPrefs.GetInt("State"+Pot);
        timer = PlayerPrefs.GetInt("Timer"+Pot);


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
            Debug.Log("State: " + state + "Planting at: " + plantingSpot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier);
        }

    }

    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("Pot"+Pot, occupier);
            PlayerPrefs.SetInt("Timer"+Pot, timer);
            PlayerPrefs.SetInt("State"+Pot, 1);
            PlayerPrefs.SetInt("Gold", gold - price);
            PlayerPrefs.Save();
            InvokeRepeating("Planting", 0f, 1f);
            NetPot.interactable = false;
            netPotChoicesBool = false;
        }
        else
        {
            netPotChoicesBool = false;
            Debug.Log("Not Enugh Gold");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State"+Pot);
        timer = PlayerPrefs.GetInt("Timer"+Pot);
        occupier = PlayerPrefs.GetString("Pot"+Pot);
        Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);

        if (occupier == "Kangkung")
        {
            if (timer <= timerStateKangkung3)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_3");
            }
            else if (timer <= timerStateKangkung2)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_2");
            }
            else
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
            }
        }
        else if(occupier == "Pokchoi") //correct spelling?
        {
            if (timer <= timerStatePokChoi3)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_3");
            }
            else if (timer <= timerStatePokChoi2)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_2");
            }
            else
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_1");
            }
        }
        else if(occupier == "Selada")
        {
            if (timer <= timerStateSelada3)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Selada_3");
            }
            else if (timer <= timerStateSelada2)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Selada_2");
            }
            else
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Selada_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State"+Pot, state);
        PlayerPrefs.SetInt("Timer"+Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            harvestButton.SetActive(true);
            CancelInvoke("Planting");
        }

        Debug.Log("Timer: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("Timer"+Pot);
        NetPot.interactable = true;
        if (timer <= 0)
        {
            Debug.Log("Timer State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Kangkung")
            {
                int lastKangkung = PlayerPrefs.GetInt("Kangkung");
                PlayerPrefs.SetInt("Kangkung", lastKangkung + 1); //increment inventory
            }
            if (occupier == "Pokchoi")
            {
                int lastPokchoi = PlayerPrefs.GetInt("Pokchoi");
                PlayerPrefs.SetInt("Pokchoi", lastPokchoi + 1); //increment inventory
            }
            if (occupier == "Selada")
            {
                int lastSelada = PlayerPrefs.GetInt("Selada");
                PlayerPrefs.SetInt("Selada", lastSelada + 1); //increment inventory
            }
            harvestButton.SetActive(false);
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("Pot"+Pot);
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
        Debug.Log("Harvested!");
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
    //    //        PlayerPrefs.SetString(plantingSpot, occupier); //pot-sekian udah ada kangkungnya
    //    //        state++;
    //    //        PlayerPrefs.SetInt(StateArray[Pot], state); //state = 1 state gamau increment?
    //    //        PlayerPrefs.SetInt(TimerArray[Pot], timerDefault);

    //    //        PlayerPrefs.Save();
    //    //        Debug.Log("Started planting with state: " + state + " Timer: " + timer);

    //    //        if (state == 1)
    //    //        {
    //    //            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
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

