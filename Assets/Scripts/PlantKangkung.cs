using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantKangkung : MonoBehaviour
{
    int state = 0;
    int timer = 4;
    public int Pot;
    public string[] PotArray = {"Pot1","Pot2","Pot3","Pot4"}; //put pots in an array
    
    GameObject childImage;
    GameObject childButton;
    GameObject netpot;
    GameObject netpotChoices;

    // Start is called before the first frame update
    void Start()
    {
        childImage = GameObject.Find("kkk");  //get first child, etc
        PlayerPrefs.SetInt("Gold",500);
        PlayerPrefs.DeleteKey(PotArray[Pot]);
        
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

        if(state == 0 && PlayerPrefs.HasKey(plantingSpot)==false)
        {
            Planting(Pot);
            netpotChoices.SetActive(false);

            Debug.Log("Planting function ran. State: " + state + "Planting at: "+ Pot);
            string occupier = PlayerPrefs.GetString(plantingSpot);    
            Debug.Log("Di pot " + plantingSpot +" ini udah ada: " + occupier);
        }

            else if(state == 0 && PlayerPrefs.HasKey(plantingSpot) == true) //something is in the pot
            {
                Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot) + " What key? " + PlayerPrefs.GetString(plantingSpot));
                // InvokeRepeating("PlantProgress",0f,1f);
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


    public void Planting(int nomor_talang)
    {
        nomor_talang = Pot;
        string plantingSpot = PotArray[nomor_talang];

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
                state++;
                Debug.Log("State added in the planting function! Current state: "+state);
                if(state == 1)
                {
                    childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
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
            }
        }
    }


   public void PlantProgress()
    {
        timer --;
        if(state == 1 && timer == 3)
        {
            state ++;
            childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_1");
            // timer = 2;
        }

        if(state == 2 && timer == 2)
        {
            state ++;
            childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_2");
            // childButton.SetActive(true);
        }
        if(state == 3 && timer == 1)
        {
            state ++;
            childImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Kangkung_3");
            // childButton.SetActive(true);
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
        state = 0;
        this.GetComponent<Button>().interactable = true;
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
        // childButton.SetActive(false);

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
