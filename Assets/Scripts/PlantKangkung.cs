using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantKangkung : MonoBehaviour
{
    int state = 1;
    int timer = 5;
    public int Pot;
    string[] PotArray = {"Pot1","Pot2","Pot3","Pot4"}; //put pots in an array
    
    GameObject childImage;
    GameObject childButton;

    // Start is called before the first frame update
    void Start()
    {
        childImage = GameObject.Find("kkk");  //get first child, etc
        childButton = this.transform.GetChild(1).gameObject;
        PlayerPrefs.SetInt("Gold",500);
<<<<<<< Updated upstream
        PlayerPrefs.Save();
        
        GoldHandler myGoldHandler = GameObject.Find("Canvas").GetComponent<GoldHandler>();
        myGoldHandler.UpdateGoldDisplay();
        // GoldHandler updateGold = new GoldHandler(); //instantiate GoldHandler object
        // updateGold.UpdateGoldDisplay(); //and call the update func from it

=======
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ClickHandler(int NomorPot)
    {
<<<<<<< Updated upstream
        PlayerPrefs.SetInt("Gold",500); //debug
        string plantingSpot = PotArray[NomorPot];

        if(state == 0 || PlayerPrefs.HasKey(plantingSpot)==false)
        {
            Planting(NomorPot);

            Debug.Log("Gold sekarang: "+ PlayerPrefs.GetInt("Gold"));
            Debug.Log("Planting function ran. State: " + state + "Planting at: "+ plantingSpot);
=======
        NomorPot = Pot;
        string plantingSpot = PotArray[NomorPot];

        if(state == 1 && PlayerPrefs.HasKey(plantingSpot)==false)
        {
            Planting(Pot);
            Debug.Log("Planting function ran. State: " + state + "Planting at: "+ Pot);
>>>>>>> Stashed changes
            string occupier = PlayerPrefs.GetString(plantingSpot);    
            Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);

        }
<<<<<<< Updated upstream
            else if(state == 1 || PlayerPrefs.HasKey(plantingSpot)==true)
            {
                Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot));
                // string ok2 = Debug.Log("Elseif after Planting function (State is one and Planting Spot has Key) ran.");
            
                //  InvokeRepeating("PlantProgress",0f,1f);
            }
                else if(state == 3)
                {
                    Harvest(NomorPot);
                    Debug.Log("Harvested! State: " + state);
                    // string ok3 = Debug.Log ("elseif to Harvest has ran.");
              
                }
                    else
                    {
                        Debug.Log("bruh");
                        Debug.Log("State: " + state + "Planting at: "+ plantingSpot);
                        string occupier = PlayerPrefs.GetString(plantingSpot);    
                        Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
                        // string bad = Debug.Log("Error function ran. State is not 1 or 3");
                    
                    }
=======
        else if(state == 1 && PlayerPrefs.HasKey(plantingSpot)==true)
        {
             Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot));
             InvokeRepeating("PlantProgress",0f,1f);
        }
        else if(state == 3)
        {
            Harvest(NomorPot);
            Debug.Log("Harvested! State: " + state);
        }
        else{
            Debug.Log("bruh");
             Debug.Log("State: " + state + "Planting at: "+ plantingSpot);
            string occupier = PlayerPrefs.GetString(plantingSpot);    
            Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
        }
>>>>>>> Stashed changes
        
    }
    public void Planting(int nomor_talang)
    {
<<<<<<< Updated upstream
        PlayerPrefs.SetInt("Gold",500); //debug
=======
        nomor_talang = Pot;
>>>>>>> Stashed changes
        string plantingSpot = PotArray[nomor_talang];

         if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
        {
            Debug.Log("Already planted here. State: " + state);
            string occupier = PlayerPrefs.GetString(plantingSpot);    
            Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
        }
<<<<<<< Updated upstream
            else
            {
                int gold = PlayerPrefs.GetInt("Gold");
                PlayerPrefs.SetString(plantingSpot,"Kangkung"); //pot-sekian udah ada kangkungnya
                
                    if(gold >= 50) //kalau gold >50 boleh
                    {
                        if (state == 0)
                        {
                            childImage = this.transform.GetChild(0).gameObject;  //get first child, etc
                            Debug.Log("ChildImage: " + childImage.GetComponent<Image>().sprite);
                            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
                            this.GetComponent<Button>().interactable = false;
                            InvokeRepeating("PlantProgess",0f,1f);
                        }
                    }
                        else if(state != 0)
                        {
                         Debug.Log("State is not zero! State: " + state);
                        }
                        else 
                        { 
                            string potState = StateArray[Pot];
                            PlayerPrefs.SetInt(potState, 0);
                            Debug.Log("Not enough money. State: " + state + "Uang sekarang: " + PlayerPrefs.GetInt("Gold"));
                        // TextMeshPro tmp_text = GetComponent<TextMeshPro>();
                        // tmp_text.enabled = true;
                        // tmp_text.CrossFadeAlpha(0.0f, 0.05f, false);
                        // tmp_text.enabled = false;
                        }
=======
        else
        {
            int gold = PlayerPrefs.GetInt("Gold");
            PlayerPrefs.SetString(plantingSpot,"Kangkung"); //pot-sekian udah ada kangkungnya
            
            if(gold > 50) //kalau gold >50 boleh
            { 
                state++;
                if(state == 1)
                {
                    childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
                    this.GetComponent<Button>().interactable = false;
                    InvokeRepeating("PlantProgress",0f,1f);
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
>>>>>>> Stashed changes
            }
    }

    void PlantProgress()
    {
        timer --;
        if(state == 1 && timer == 4)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
            // timer = 2;
        }

        if(state == 2 && timer == 2)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_2");
            childButton.SetActive(true);
        }
        if(state == 3 && timer == 1)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_3");
            childButton.SetActive(true);
        }
        else if(timer == 0)
        {
            CancelInvoke("PlantProgress");
        }
        Debug.Log("Timer: " + timer + " State: "+state);
    }

    public void Harvest(int nomor_talang)
    {
        nomor_talang = Pot;
        string plantingSpot = PotArray[nomor_talang];
        state = 1;
        this.GetComponent<Button>().interactable = true;
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
        childButton.SetActive(false);

        CancelInvoke("PlantProgress");
        timer = 0;

        int lastKangkung = PlayerPrefs.GetInt("Kangkung");
        PlayerPrefs.SetInt("Kangkung", lastKangkung+1); //increment inventory
        // PlayerPrefs.SetInt("Gold", lastGold+20); <- dapet gold saat menjual, pindah ke Rumah nanti
        PlayerPrefs.Save();
        PlayerPrefs.DeleteKey(plantingSpot);
    }
    // PlayerPrefs.Save(); call this on scene exit
}
