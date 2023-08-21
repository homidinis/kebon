using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantFunction_Kebun : MonoBehaviour
{
    public int Pot;

    int state = 0;
    float timer = 0;

    int price;

    int priceDefaultJagung = 150;
    int priceDefaultBawang = 150;
    int priceDefaultEdamame = 150;

    float timerDefaultJagung = 300 * GlobalVariable.pupukBuff / 100;
    float timerStateJagung2 = 150 * GlobalVariable.pupukBuff / 100;
    float timerStateJagung3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultBawang = 300 * GlobalVariable.pupukBuff / 100;
    float timerStateBawang2 = 150 * GlobalVariable.pupukBuff / 100;
    float timerStateBawang3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultEdamame = 300 * GlobalVariable.pupukBuff / 100;
    float timerStateEdamame2 = 150 * GlobalVariable.pupukBuff / 100;
    float timerStateEdamame3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject PlantspotChoices;
    bool PlantspotChoicesBool = false;
    GameObject PlantspotSprite;
    GameObject timerText;
    GameObject timerBG;
    GameObject gloves;
    string occupier;
    Button Plantspot;

    // Start is called before the first frame update
    void Start()
    {
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        PlantspotSprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        PlantspotChoices = transform.parent.gameObject.transform.GetChild(4).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(8).gameObject;
        timerText = transform.parent.gameObject.transform.GetChild(6).gameObject;
        timerBG = transform.parent.gameObject.transform.GetChild(5).gameObject;
        gloves = transform.parent.gameObject.transform.GetChild(7).gameObject;
        Plantspot = this.transform.parent.GetComponent<Button>();
        //Debug.Log("PlantingSpotArray " + "PlantingSpot" + Pot);
        //Debug.Log("Haskey " + PlayerPrefs.HasKey("State_Kebun" + Pot));
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
        timer = PlayerPrefs.GetFloat("Timer_Kebun"+Pot);


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
            //Debug.Log("State_Kebun: " + state + "Planting at: " + plantingSpot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            //Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier);
        }

    }

    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("PlantingSpot"+Pot, occupier);
            PlayerPrefs.SetFloat("Timer_Kebun"+Pot, timer);
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
            //Debug.Log("Not Enugh Gold");
            Alert.ShowAlert("Gold Tidak cukup!");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State_Kebun"+Pot);
        timer = PlayerPrefs.GetFloat("Timer_Kebun"+Pot);
        occupier = PlayerPrefs.GetString("PlantingSpot"+Pot);
        //Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        PlantspotSprite.GetComponent<Image>().enabled = true;
        timerBG.SetActive(true);
        timerText.SetActive(true);
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0}:{1:00}", minutes, seconds);
        timerText.GetComponent<TextMeshProUGUI>().text = niceTime;
        if (occupier == "Jagung")
        {
            if (timer <= timerStateJagung3)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Jagung_3");
            }
            else if (timer <= timerStateJagung2)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Jagung_2");
            }
            else
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Jagung_1");
            }
        }
        else if(occupier == "Bawang") //correct spelling?
        {
            if (timer <= timerStateBawang3)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Bawang_3");
            }
            else if (timer <= timerStateBawang2)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Bawang_2");
            }
            else
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Bawang_1");
            }
        }
        else if(occupier == "Edamame")
        {
            if (timer <= timerStateEdamame3)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Edamame_3");
            }
            else if (timer <= timerStateEdamame2)
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Edamame_2");
            }
            else
            {
                PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Tanaman_Edamame_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State_Kebun"+Pot, state);
        PlayerPrefs.SetFloat("Timer_Kebun"+Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            int zero = 0;
            timerText.GetComponent<TextMeshProUGUI>().text = zero.ToString();
            harvestButton.SetActive(true);
            gloves.SetActive(true);
            CancelInvoke("Planting");
        }

        //Debug.Log("Timer_Kebun: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        float timer = PlayerPrefs.GetFloat("Timer_Kebun"+Pot);
        Plantspot.interactable = true;
        if (timer <= 0)
        {
            //Debug.Log("Timer_Kebun State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
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
            //Debug.Log("Blom bisa di harvest. State_Kebun: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("PlantingSpot"+Pot);
        PlantspotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/placeholder");
        timerBG.SetActive(false);
        timerText.SetActive(false);
        gloves.SetActive(false);
        //Debug.Log("Harvested " + occupier);
        Alert.ShowAlert("Harvested " + occupier + " x1");
    }
}


