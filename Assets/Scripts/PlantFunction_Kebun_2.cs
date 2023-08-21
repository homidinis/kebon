using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantFunction_Kebun_2 : MonoBehaviour
{
    public int Pot;

    int state = 0;
    float timer = 0;

    int price;

    int priceDefaultJambu = 200;
    int priceDefaultLengkeng = 200;
    int priceDefaultPepaya = 200;
    int priceDefaultRambutan = 200;
    int priceDefaultPisang = 200;

    float timerDefaultJambu = 400 * GlobalVariable.pupukBuff / 100;
    float timerStateJambu2 = 200 * GlobalVariable.pupukBuff / 100;
    float timerStateJambu3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultLengkeng = 400 * GlobalVariable.pupukBuff / 100;
    float timerStateLengkeng2 = 200 * GlobalVariable.pupukBuff / 100;
    float timerStateLengkeng3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultPepaya = 400 * GlobalVariable.pupukBuff / 100;
    float timerStatePepaya2 = 200 * GlobalVariable.pupukBuff / 100;
    float timerStatePepaya3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultRambutan = 400 * GlobalVariable.pupukBuff / 100;
    float timerStateRambutan2 = 200 * GlobalVariable.pupukBuff / 100;
    float timerStateRambutan3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultPisang = 400 * GlobalVariable.pupukBuff / 100;
    float timerStatePisang2 = 200 * GlobalVariable.pupukBuff / 100;
    float timerStatePisang3 = 1 * GlobalVariable.pupukBuff / 100;
    float timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject Plantspot2Choices;
    bool Plantspot2ChoicesBool = false;
    GameObject Plantspot2Sprite;
    GameObject timerText;
    GameObject timerBG;
    GameObject gloves;
    string occupier;
    Button Plantspot2;

    // Start is called before the first frame update
    void Start()
    {
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        Plantspot2Sprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        Plantspot2Choices = transform.parent.gameObject.transform.GetChild(4).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(8).gameObject;
        timerText = transform.parent.gameObject.transform.GetChild(6).gameObject;
        timerBG = transform.parent.gameObject.transform.GetChild(5).gameObject;
        gloves = transform.parent.gameObject.transform.GetChild(7).gameObject;
        Plantspot2 = this.transform.parent.GetComponent<Button>();
        //Debug.Log("PlantingSpotArray " + "PlantingSpot2" + Pot);
        //Debug.Log("Haskey " + PlayerPrefs.HasKey("State_Kebun2" + Pot));
        if (PlayerPrefs.HasKey("PlantingSpot2"+Pot))
        {
            InvokeRepeating("Planting", 0f, 1f);
        }
    }

    public void Toogle()
    {
        if (!Plantspot2ChoicesBool)
        {
            Plantspot2ChoicesBool = true;
            Plantspot2Choices.SetActive(true);
        }
        else
        {
            Plantspot2ChoicesBool = false;
            Plantspot2Choices.SetActive(false);
        }
    }

    public void PlantJambu()
    {
        occupier = "Jambu";
        timer = timerDefaultJambu;
        price = priceDefaultJambu;
        Buy();
    }
    public void PlantLengkeng()
    {
        occupier = "Lengkeng";
        timer = timerDefaultLengkeng;
        price = priceDefaultLengkeng;
        Buy();
    }
    public void PlantPepaya()
    {
        occupier = "Pepaya"; //set Pepaya here jadi kode dibawah tau kalau occupier sudah jadi Pepaya 
        timer = timerDefaultPepaya;
        price = priceDefaultPepaya;
        Buy();
    }
    public void PlantRambutan()
    {
        occupier = "Rambutan"; //set Pepaya here jadi kode dibawah tau kalau occupier sudah jadi Pepaya 
        timer = timerDefaultRambutan;
        price = priceDefaultRambutan;
        Buy();
    }
    public void PlantPisang()
    {
        occupier = "Pisang"; //set Pepaya here jadi kode dibawah tau kalau occupier sudah jadi Pepaya 
        timer = timerDefaultPisang;
        price = priceDefaultPisang;
        Buy();
    }

    public void ClickHandler()
    {
        string plantingSpot = "PlantingSpot2"+Pot;
        state = PlayerPrefs.GetInt("State_Kebun2"+Pot);
        timer = PlayerPrefs.GetFloat("Timer_Kebun2"+Pot);


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
            PlayerPrefs.SetString("PlantingSpot2"+Pot, occupier);
            PlayerPrefs.SetFloat("Timer_Kebun2"+Pot, timer);
            PlayerPrefs.SetInt("State_Kebun2"+Pot, 1);
            PlayerPrefs.SetInt("Gold", gold - price);
            PlayerPrefs.Save();
            InvokeRepeating("Planting", 0f, 1f);
            Plantspot2.interactable = false;
            Plantspot2ChoicesBool = false;
        }
        else
        {
            Plantspot2ChoicesBool = false;
            Debug.Log("Not Enough Gold");
            Alert.ShowAlert("Gold Tidak cukup!");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State_Kebun2"+Pot);
        timer = PlayerPrefs.GetFloat("Timer_Kebun2"+Pot);
        occupier = PlayerPrefs.GetString("PlantingSpot2"+Pot);
        //Debug.Log("Occupier " + occupier);
        //Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        Plantspot2Sprite.GetComponent<Image>().enabled = true;
        timerBG.SetActive(true);
        timerText.SetActive(true);
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0}:{1:00}", minutes, seconds);
        timerText.GetComponent<TextMeshProUGUI>().text = niceTime;
        if (occupier == "Jambu")
        {
            if (timer <= timerStateJambu3)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Jambu_3");
            }
            else if (timer <= timerStateJambu2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Jambu_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Jambu_1");
            }
        }
        else if(occupier == "Lengkeng") //correct spelling?
        {
            if (timer <= timerStateLengkeng3)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Lengkeng_3");
            }
            else if (timer <= timerStateLengkeng2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Lengkeng_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Lengkeng_1");
            }
        }
        else if(occupier == "Pepaya")
        {
            if (timer <= timerStatePepaya3)
            {   
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Papaya_3");
            }
            else if (timer <= timerStatePepaya2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Papaya_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Papaya_1");
            }
        }
        else if(occupier == "Rambutan")
        {
            if (timer <= timerStateRambutan3)
            {   
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Rambutan_3");
            }
            else if (timer <= timerStateRambutan2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Rambutan_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Rambutan_1");
            }

        }
        else if(occupier == "Pisang")
        {
            if (timer <= timerStatePisang3)
            {   
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Pisang_3");
            }
            else if (timer <= timerStatePisang2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Pisang_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Pohon_Pisang_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State_Kebun2"+Pot, state);
        PlayerPrefs.SetFloat("Timer_Kebun2"+Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            int zero = 0;
            timerText.GetComponent<TextMeshProUGUI>().text = zero.ToString();
            harvestButton.SetActive(true);
            CancelInvoke("Planting");
            gloves.SetActive(true);
        }

        //Debug.Log("Timer_Kebun2: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("Timer_Kebun2"+Pot);
        Plantspot2.interactable = true;
        if (timer <= 0)
        {
            //Debug.Log("Timer_Kebun2 State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
            if (occupier == "Jambu")
            {
                int lastJambu = PlayerPrefs.GetInt("Jambu");
                PlayerPrefs.SetInt("Jambu", lastJambu + 1); //increment inventory
            }
            if (occupier == "Lengkeng")
            {
                int lastLengkeng = PlayerPrefs.GetInt("Lengkeng");
                PlayerPrefs.SetInt("Lengkeng", lastLengkeng + 1); //increment inventory
            }
            if (occupier == "Pepaya")
            {
                int lastPepaya = PlayerPrefs.GetInt("Pepaya");
                PlayerPrefs.SetInt("Pepaya", lastPepaya + 1); //increment inventory
            }
            if (occupier == "Rambutan")
            {
                int lastRambutan = PlayerPrefs.GetInt("Rambutan");
                PlayerPrefs.SetInt("Rambutan", lastRambutan + 1); //increment inventory
            }
            if (occupier == "Pisang")
            {
                int lastPisang = PlayerPrefs.GetInt("Pisang");
                PlayerPrefs.SetInt("Pisang", lastPisang + 1); //increment inventory
            }
            harvestButton.SetActive(false);
        }

        else
        {
            //Debug.Log("Blom bisa di harvest. State_Kebun2: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("PlantingSpot2"+Pot);
        Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/placeholder");
        timerText.SetActive(false);
        timerBG.SetActive(false);
        gloves.SetActive(false);
        //Debug.Log("Harvested " + occupier);
        Alert.ShowAlert("Harvested " + occupier + " x1");

    }
}

