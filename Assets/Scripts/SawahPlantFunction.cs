using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SawahPlantFunction : MonoBehaviour
{
    public int Pot;

    int state = 0;
    int timer = 0;

    int price;

    int priceDefaultPadi = 50;

    int timerDefaultPadi = 10 * (GlobalVariable.pupukBuff / 100);
    int timerStatePadi2 = 5 * (GlobalVariable.pupukBuff / 100);
    int timerStatePadi3 = 1 * (GlobalVariable.pupukBuff / 100);

    int timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject NetPotChoices;
    bool netPotChoicesBool = false;
    GameObject NetPotSprite;

    string occupier;
    Button NetPot;

    // Start is called before the first frame update
    void Start()
    {
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        NetPotSprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        NetPotChoices = transform.parent.gameObject.transform.GetChild(5).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(4).gameObject;
        NetPot = this.transform.parent.GetComponent<Button>();
        Debug.Log("PotArray " + "Spot" + Pot);
        Debug.Log("Haskey " + PlayerPrefs.HasKey("State" + Pot));
        if (PlayerPrefs.HasKey("Spot" + Pot))
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
    public void PlantPadi()
    {
        occupier = "Padi";
        timer = timerDefaultPadi;
        price = priceDefaultPadi;
        //ClickHandler();
        Buy();
    }


    public void ClickHandler()
    {
        string plantingSpot = "Spot" + Pot;
        state = PlayerPrefs.GetInt("State" + Pot);
        timer = PlayerPrefs.GetInt("TimerSawah" + Pot);


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
            PlayerPrefs.SetString("Spot" + Pot, occupier);
            PlayerPrefs.SetInt("TimerSawah" + Pot, timer);
            PlayerPrefs.SetInt("State" + Pot, 1);
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
        state = PlayerPrefs.GetInt("State" + Pot);
        timer = PlayerPrefs.GetInt("TimerSawah" + Pot);
        occupier = PlayerPrefs.GetString("Spot" + Pot);
        Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        NetPotSprite.GetComponent<Image>().enabled = true;

        if (occupier == "Padi")
        {
            if (timer <= timerStatePadi3)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("ubahh-/pDI/Tanaman_Padi_3");
            }
            else if (timer <= timerStatePadi2)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("ubahh-/pDI/Tanaman_Padi_2");
            }
            else
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("ubahh-/pDI/Tanaman_Padi_1");
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("ubahh-/pDI/Tanaman_Padi_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State" + Pot, state);
        PlayerPrefs.SetInt("TimerSawah" + Pot, timer);
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
        int timer = PlayerPrefs.GetInt("TimerSawah" + Pot);
        NetPot.interactable = true;
        if (timer <= 0)
        {
            Debug.Log("Timer State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Padi")
            {
                int lastPadi = PlayerPrefs.GetInt("Nasi");
                PlayerPrefs.SetInt("Nasi", lastPadi + 4); //increment inventory
            }
            harvestButton.SetActive(false);
        }

        else
        {
            Debug.Log("Blom bisa di harvest. State: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("Spot" + Pot);
        NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/placeholder");
        Debug.Log("Harvested! " + occupier);
    }
}

