using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantKangkung : MonoBehaviour
{
    // public int state = 0; //STATE 0 UNPLANTED, STATE 1 PLANTED, 2 JUVENILE, 3 HARVEST READY
    // public int timer = 4; 
    public int Pot;
    int timer;
    int state;
    string[] PotArray = {"Pot1","Pot2","Pot3","Pot4"}; //put pots in an array
    string[] StateArray = {"StatePot1","StatePot2","StatePot3","StatePot4"};
    string[] TimerArray = {"TimerPot1","TimerPot2","TimerPot3","TimerPot4"};


    
    
    GameObject childImage;
    GameObject childButton;
    GameObject netpot;
    GameObject netpotChoices;

    // Start is called before the first frame update
    void Start()
    {
        
        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);
        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);
        
        string CurrentPot = PotArray[Pot];
        childImage = GameObject.Find("kkk");  //get first child, etc
        PlayerPrefs.SetInt("Gold",500);
        
        Debug.Log("Welcome to hell! State of this pot: " + state + "Timer of this pot: " + timer + "PotArray of this pot: " + CurrentPot);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ClickHandler(int NomorPot)
    {
        NomorPot = Pot;
        string plantingSpot = PotArray[NomorPot];
        netpot = GameObject.Find("Netpot_1");
        netpotChoices = netpot.transform.GetChild(1).gameObject;

        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);
        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);
        
        if(state >= 0 && timer >= 0)
        {
            netpotChoices.SetActive(false);
        }

        if(state == 0 && PlayerPrefs.HasKey(plantingSpot)==false)
        {
            Planting();

            // string occupier = PlayerPrefs.GetString(plantingSpot);    
            // Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
        }

            else if(state == 0 && PlayerPrefs.HasKey(plantingSpot) == true) //something is in the pot
            {
                Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot) + " What key? " + PlayerPrefs.GetString(plantingSpot));
                InvokeRepeating("PlantProgress",0f,1f);
            }

                else if(state == 2 && timer == 0) //ready
                {
                    Harvest(NomorPot);
                    Debug.Log("Harvested! State: " + state);
                }

                    else
                    {
                        Debug.Log("bruh");
                        Debug.Log("State: " + state + "Planting at: "+ plantingSpot);
                        string occupier = PlayerPrefs.GetString(plantingSpot);    
                        Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
                    }
        
    }

    public void Planting()
    {
        
        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);

        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);

        string plantingSpot = PotArray[Pot];
                Debug.Log("Planting function ran. State: " + state + " Planting at: "+ plantingSpot);

         if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
        {
            Debug.Log("Already planted here. State: " + state);
            string occupier = PlayerPrefs.GetString(plantingSpot);    
            Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
        }
        else
        {
            int gold = PlayerPrefs.GetInt("Gold");
            PlayerPrefs.SetString(plantingSpot,"Kangkung"); //pot-sekian udah ada kangkungnya
            
            if(gold > 50) //kalau gold >50 boleh
            {
                int currentState = state++;
                PlayerPrefs.SetInt(StateArrayKey, currentState);
                PlayerPrefs.Save();
                Debug.Log("State added in the planting function! Current state: " + state);

                if(state == 1)
                {  
                    PlayerPrefs.SetInt(TimerArrayKey,3);
                    InvokeRepeating("PlantProgress",0f,1f);
                    Debug.Log("Invoke repeating ran. " + state + " " + timer);
                }
            }
            else
            {
                state = 0;  
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
        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);

        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);

        if(state == 1 && timer == 3)
        {
            int currentState = state++;
            PlayerPrefs.SetInt(StateArrayKey, currentState);
            childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
            Debug.Log("Current state: "+state);
            PlayerPrefs.Save();

        }

        if(state == 2 && timer == 2)
        {
            int currentState = state++;
            PlayerPrefs.SetInt(StateArrayKey, currentState);
            childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_2");
            Debug.Log("Current state: "+state);
            PlayerPrefs.Save();
        }
        if(state == 3 && timer == 1)
        {
            state = PlayerPrefs.GetInt(StateArrayKey);
            int currentState = state++;
            PlayerPrefs.SetInt(StateArrayKey, currentState);
            childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_3");
            Debug.Log("Current state: "+state);
            PlayerPrefs.Save();
        }
        else if(timer == 0)
        {
            CancelInvoke("PlantProgress");
            Debug.Log("Current state: "+state);
            PlayerPrefs.Save();
        }
        timer --;
        
    }
    
    public void Harvest(int nomor_talang)
    {
        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);

        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);

        nomor_talang = Pot;
        string plantingSpot = PotArray[Pot];

        PlayerPrefs.SetInt(StateArrayKey,0);
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
        CancelInvoke("PlantProgress");
        timer = 0;
        int lastKangkung = PlayerPrefs.GetInt("Kangkung");
        int lastGold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Kangkung", lastKangkung+1); //increment inventory
        PlayerPrefs.SetInt("Gold", lastGold+20);
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey(plantingSpot);
    }
    // PlayerPrefs.Save(); call this on scene exit
}
