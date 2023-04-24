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

    int timerDefaultPokChoi = 4;
    int timerStatePokChoi1 = 10;
    int timerStatePokChoi2 = 10;
    int timerStatePokChoi3 = 10;

    int timerDefaultSelada = 5;
    int timerStateSelada1 = 5;
    int timerStateSelada2 = 5;
    int timerStateSelada3 = 5;

    int timerDefault;

    string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4" }; //put pots in an array
    string[] StateArray = { "StatePot1", "StatePot2", "StatePot3" };
    string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3" };

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
        PlayerPrefs.SetInt("Gold", 500);
        NetPot = this.transform.parent.GetComponent<Button>();
        Debug.Log("PotArray " + PotArray[Pot]);
        Debug.Log("Haskey " + PlayerPrefs.HasKey(PotArray[Pot]));
        if (PlayerPrefs.HasKey(PotArray[Pot]))
        {
            InvokeRepeating("PlantProgress", 0f, 1f);
        }
        else
        {
           // InvokeRepeating("PlantProgress", 0f, 1f);
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
        NetPot.interactable = false;
        timer = timerDefaultKangkung;
        price = priceDefaultKangkung;
        //ClickHandler();
        Buy();
    }
    public void PlantPokchoi()
    {
        occupier = "Pokchoi";
        NetPot.interactable = false;
        timer = timerDefaultPokChoi;
        price = priceDefaultPokChoi;
        //ClickHandler();
        Buy();
    }
    public void PlantSelada()
    {
        occupier = "Selada"; //set selada here jadi kode dibawah tau kalau occupier sudah jadi selada 
        NetPot.interactable = false;
        timer = timerDefaultSelada;
        price = priceDefaultSelada;
        //ClickHandler();
        Buy();
    }

    public void ClickHandler()
    {
        string plantingSpot = PotArray[Pot];
        state = PlayerPrefs.GetInt(StateArray[Pot]);
        int timer = PlayerPrefs.GetInt(TimerArray[Pot]);


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

            Debug.Log("PotArray " + PotArray[Pot]);
            PlayerPrefs.SetString(PotArray[Pot], occupier);
            PlayerPrefs.SetInt(TimerArray[Pot], timer);
            PlayerPrefs.SetInt(StateArray[Pot], 1);
            PlayerPrefs.Save();
            InvokeRepeating("PlantProgress", 0f, 1f);
        }
    }


    public void Planting()
    {
        
        //int state = 0;
        //int timer = timerDefault;

        //string plantingSpot = PotArray[Pot];

        //if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
        //{
        //    Debug.Log("Already planted here. State: " + state);
        //    Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier + " dengan state: " + state);
        //}
        //else
        //{
        //    int gold = PlayerPrefs.GetInt("Gold");

        //    if (gold > 50) 
        //    {
        //        PlayerPrefs.SetString(plantingSpot, occupier); //pot-sekian udah ada kangkungnya
        //        state++;
        //        PlayerPrefs.SetInt(StateArray[Pot], state); //state = 1 state gamau increment?
        //        PlayerPrefs.SetInt(TimerArray[Pot], timerDefault);

        //        PlayerPrefs.Save();
        //        Debug.Log("Started planting with state: " + state + " Timer: " + timer);

        //        if (state == 1)
        //        {
        //            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
        //            InvokeRepeating("PlantProgress", 0f, 1f);
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("Not enough money. State: " + state + "Uang sekarang: " + PlayerPrefs.GetInt("Gold"));
        //        // TextMeshPro tmp_text = GetComponent<TextMeshPro>();
        //        // tmp_text.enabled = true;
        //        // tmp_text.CrossFadeAlpha(0.0f, 0.05f, false);
        //        // tmp_text.enabled = false;
        //    }
        //}
    }


    public void PlantProgress()
    {
        state = PlayerPrefs.GetInt(StateArray[Pot]);
        timer = PlayerPrefs.GetInt(TimerArray[Pot]);
        occupier = PlayerPrefs.GetString(PotArray[Pot]);
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
        else if(occupier == "PokChoi") //correct spelling?
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

        //if (state == 1 && timer <= timerState1)
        //{
        //    Debug.Log("State 1 Called");
        //    state++;
        //}
        //if (state == 2 && timer <= timerState2)
        //{
        //    Debug.Log("State 2 Called");
        //    state++;
        //}
        //if (state == 3 && timer <= timerState3)
        //{
        //    Debug.Log("State 3 Called");
        //    state++;
        //}

        timer--;
        PlayerPrefs.SetInt(StateArray[Pot], state);
        PlayerPrefs.SetInt(TimerArray[Pot], timer);
        PlayerPrefs.Save();

        if (timer <= 0 && state == 4)
        {
            CancelInvoke("PlantProgress");
        }

        Debug.Log("Timer: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt(TimerArray[Pot]);
        NetPot.interactable = true;
        if (timer == 0 && state == 4)
        {
            Debug.Log("Timer State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Kangkung")
            {
                string plantingSpot = PotArray[Pot];
                //RESET TIMER AND STATE, todo: insert to PlayerPrefs
                int state = 0;
                PlayerPrefs.SetInt(StateArray[Pot],state);
                timer = 4;
                PlayerPrefs.SetInt(TimerArray[Pot],timer); 
                int lastKangkung = PlayerPrefs.GetInt("Kangkung");
                PlayerPrefs.SetInt("Kangkung", lastKangkung + 1); //increment inventory
                PlayerPrefs.Save();
                PlayerPrefs.DeleteKey(plantingSpot);

                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
                Debug.Log("Harvested!");
            }

            if (occupier == "Pokchoi")
            {
                string plantingSpot = PotArray[Pot];
                //RESET TIMER AND STATE, todo: insert to PlayerPrefs
                state = 0;
                PlayerPrefs.SetInt(StateArray[Pot],state);
                timer = 4;

                int lastPokchoi = PlayerPrefs.GetInt("Pokchoi");
                PlayerPrefs.SetInt("Pokchoi", lastPokchoi + 1); //increment inventory
                PlayerPrefs.Save();
                PlayerPrefs.DeleteKey(plantingSpot);
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
            }

            if (occupier == "Selada")
            {
                string plantingSpot = PotArray[Pot];
                //RESET TIMER AND STATE, todo: insert to PlayerPrefs
                state = 0;
                PlayerPrefs.SetInt(StateArray[Pot], state);
                timer = 4;

                int lastSelada = PlayerPrefs.GetInt("Selada");
                PlayerPrefs.SetInt("Selada", lastSelada + 1); //increment inventory
                PlayerPrefs.Save();
                PlayerPrefs.DeleteKey(plantingSpot);
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
            }
            harvestButton.SetActive(false);
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State: " + state + "/4 dan Timer: " + timer + "/0");
        }
    }

}

//int lastGold = PlayerPrefs.GetInt("Gold");
//PlayerPrefs.SetInt("Gold", lastGold+20); //<- dapet gold saat menjual, pindah ke Rumah nanti
//PlayerPrefs.Save(); call this on scene exit

