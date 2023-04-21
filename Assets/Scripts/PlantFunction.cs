using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantFunction : MonoBehaviour
{
    public int Pot;
    public int state = 0;

    int timerDefaultKangkung = 3;
    int timerDefaultPokChoy = 4;
    int timerDefaultSelada = 5;
    int timerDefault;
    int timerState1 = 3;
    int timerState2 = 2;
    int timerState3 = 1;

    string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4" }; //put pots in an array
    string[] StateArray = { "StatePot1", "StatePot2", "StatePot3" };
    string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3" };

    GameObject childImage;

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
        PlayerPrefs.SetInt("Gold", 500);
        PlayerPrefs.DeleteKey("Pot1");
        NetPot = this.transform.parent.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void ClickHandler(int NomorPot)
    {
        NomorPot = Pot;
        string plantingSpot = PotArray[NomorPot];
        state = PlayerPrefs.GetInt(StateArray[NomorPot]);
        int timer = PlayerPrefs.GetInt(TimerArray[NomorPot]);


        if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == false)
        {
            Planting(Pot);
            
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
            Harvest(NomorPot);
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

    public void PlantKangkung(int nomor_talang)
    {

        occupier = "Kangkung";
        NetPot.interactable = false;
        timerDefault = timerDefaultKangkung;
        ClickHandler(nomor_talang);

    }
    public void PlantPokchoi(int nomor_talang)
    {
        occupier = "Pokchoi";
        NetPot.interactable = false;
        timerDefault = timerDefaultPokChoy;
        ClickHandler(nomor_talang);
    }
    public void PlantSelada(int nomor_talang)
    {
        occupier = "Selada"; //set selada here jadi kode dibawah tau kalau occupier sudah jadi selada 
        NetPot.interactable = false;
        timerDefault = timerDefaultSelada;
        ClickHandler(nomor_talang);
    }


    public void Planting(int nomor_talang)
    {
        int state = 0;
        int timer = timerDefault;
        
        string plantingSpot = PotArray[nomor_talang];

        if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
        {
            Debug.Log("Already planted here. State: " + state);
            Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier + " dengan state: " + state);
        }
        else
        {
            int gold = PlayerPrefs.GetInt("Gold");

            if (gold > 50) //kalau gold >50 boleh
            {
                PlayerPrefs.SetString(plantingSpot, "Kangkung"); //pot-sekian udah ada kangkungnya
                state++;
                PlayerPrefs.SetInt(StateArray[nomor_talang], state); //state = 1 state gamau increment?
                PlayerPrefs.SetInt(TimerArray[nomor_talang], timerDefault);

                PlayerPrefs.Save();
                Debug.Log("Started planting with state: " + state + " Timer: " + timer);

                if (state == 1)
                {
                    childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
                    InvokeRepeating("PlantProgress", 0f, 1f);
                }
            }
            else
            {
                Debug.Log("Not enough money. State: " + state + "Uang sekarang: " + PlayerPrefs.GetInt("Gold"));
                // TextMeshPro tmp_text = GetComponent<TextMeshPro>();
                // tmp_text.enabled = true;
                // tmp_text.CrossFadeAlpha(0.0f, 0.05f, false);
                // tmp_text.enabled = false;
            }
        }
    }


    public void PlantProgress()
    {
        state = PlayerPrefs.GetInt(StateArray[Pot]);
        int timer = PlayerPrefs.GetInt(TimerArray[Pot]);
        if (state == 1 && timer == timerState1)
        {
            state++;
            PlayerPrefs.SetInt(StateArray[Pot], state);
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
            PlayerPrefs.Save();
            // timer = 2;
        }

        if (state == 2 && timer == timerState2)
        {
            state++;
            PlayerPrefs.SetInt(StateArray[Pot], state);
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_2");
            PlayerPrefs.Save();
        }

        if (state == 3 && timer == timerState3)
        {
            state++;
            PlayerPrefs.SetInt(StateArray[Pot], state);
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_3");
            PlayerPrefs.Save();
        }
        timer--;
        PlayerPrefs.SetInt(TimerArray[Pot], timer);
        PlayerPrefs.Save();

        if (timer == 0 && state == 4)
        {
            CancelInvoke("PlantProgress");
        }

        Debug.Log("Timer: " + timer + " State: " + state);
    }

    public void Harvest(int nomor_talang)
    {
        int timer = PlayerPrefs.GetInt(TimerArray[nomor_talang]);
        NetPot.interactable = true;
        if (timer == 0 && state == 4)
        {
            Debug.Log("Timer State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Kangkung")
            {
                nomor_talang = Pot;
                string plantingSpot = PotArray[nomor_talang];
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
                nomor_talang = Pot;
                string plantingSpot = PotArray[nomor_talang];
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
                nomor_talang = Pot;
                string plantingSpot = PotArray[nomor_talang];
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
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State: " + state + "/4 dan Timer: " + timer + "/0");
        }
    }





    public void ResetPot()
    {
        int timer = PlayerPrefs.GetInt(TimerArray[Pot]);
        int gold = PlayerPrefs.GetInt("Gold");
        string plantingSpot = PotArray[Pot];
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted Everything! Current Playerprefs: STATE: " + state + " TIMER: " + timer + " GOLD: " + gold + " KEY IN POT: " + plantingSpot);
    }

    public void addGold()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", 500);
        Debug.Log("Added gold! Current gold: " + gold);
    }
}

//int lastGold = PlayerPrefs.GetInt("Gold");
//PlayerPrefs.SetInt("Gold", lastGold+20); //<- dapet gold saat menjual, pindah ke Rumah nanti
//PlayerPrefs.Save(); call this on scene exit

