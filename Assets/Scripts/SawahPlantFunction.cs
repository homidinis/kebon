using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SawahPlantFunction : MonoBehaviour
{
    public int Pot;

    int state = 0;
    float timer = 0;

    int price;

    int priceDefaultPadi = 300;

    float timerDefaultPadi = 500 * GlobalVariable.pupukBuff / 100;
    float timerStatePadi2 = 250 * GlobalVariable.pupukBuff / 100;
    float timerStatePadi3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject NetPotChoices;
    bool netPotChoicesBool = false;
    GameObject NetPotSprite;
    GameObject timerText;
    GameObject timerBG;
    GameObject gloves;
    string occupier;
    Button NetPot;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Pupuk buff" + GlobalVariable.pupukBuff);
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        NetPotSprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        NetPotChoices = transform.parent.gameObject.transform.GetChild(4).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(8).gameObject;
        timerText = transform.parent.gameObject.transform.GetChild(6).gameObject;
        timerBG = transform.parent.gameObject.transform.GetChild(5).gameObject;
        gloves = transform.parent.gameObject.transform.GetChild(7).gameObject;
        NetPot = this.transform.parent.GetComponent<Button>();
        //Debug.Log("PotArray " + "Spot" + Pot);
        //Debug.Log("Haskey " + PlayerPrefs.HasKey("State" + Pot));
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
        Buy();
    }


    public void ClickHandler()
    {
        string plantingSpot = "Spot" + Pot;
        state = PlayerPrefs.GetInt("State" + Pot);
        timer = PlayerPrefs.GetFloat("TimerSawah" + Pot);


        if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == false)
        {
            Planting();
            //Debug.Log("Planting function ran. State: " + state + "Planting at PotArray no. : " + Pot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            //Debug.Log("Di pot " + plantingSpot + " sekarang udah ada: " + occupier);

        }

        else if (state == 0 && PlayerPrefs.HasKey(plantingSpot) == true)
        {
            //Debug.Log("HasKey? " + PlayerPrefs.HasKey(plantingSpot));
        }

        else if (state == 3)
        {
            Harvest();
            //Debug.Log("Harvested! State: " + state);
        }

        else
        {
            //Debug.Log("bruh. State: " + state);
            //Debug.Log("State: " + state + "Planting at: " + plantingSpot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            //Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier);
        }

    }

    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("Spot" + Pot, occupier);
            PlayerPrefs.SetFloat("TimerSawah" + Pot, timer);
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
            //Debug.Log("Not Enugh Gold");
            Alert.ShowAlert("Gold Tidak cukup!");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State" + Pot);
        timer = PlayerPrefs.GetFloat("TimerSawah" + Pot);
        occupier = PlayerPrefs.GetString("Spot" + Pot);
        //Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        NetPotSprite.GetComponent<Image>().enabled = true;
        timerBG.SetActive(true); 
        timerText.SetActive(true);
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0}:{1:00}", minutes, seconds);
        timerText.GetComponent<TextMeshProUGUI>().text = niceTime;
        if (occupier == "Padi")
        {
            if (timer <= timerStatePadi3)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Padi_3");
            }
            else if (timer <= timerStatePadi2)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Padi_2");
            }
            else
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Padi_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State" + Pot, state);
        PlayerPrefs.SetFloat("TimerSawah" + Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            int zero = 0;
            timerText.GetComponent<TextMeshProUGUI>().text = zero.ToString();
            harvestButton.SetActive(true);
            CancelInvoke("Planting");
            gloves.SetActive(true);
        }

        //Debug.Log("Timer: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("TimerSawah" + Pot);
        NetPot.interactable = true;
        if (timer <= 0)
        {
            //Debug.Log("Timer State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Padi")
            {
                int lastPadi = PlayerPrefs.GetInt("Nasi");
                PlayerPrefs.SetInt("Nasi", lastPadi + 4); //increment inventory
            }
            harvestButton.SetActive(false);
        }

        else
        {
            //Debug.Log("Blom bisa di harvest. State: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("Spot" + Pot);
        NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/placeholder");
        timerBG.SetActive(false);
        timerText.SetActive(false);
        gloves.SetActive(false);
        //Debug.Log("Harvested! " + occupier);
        Alert.ShowAlert("Harvested " + occupier + " x1");
    }
}

