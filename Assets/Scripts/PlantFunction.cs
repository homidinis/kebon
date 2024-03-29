using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlantFunction : MonoBehaviour
{
    public int Pot;

    int state = 0;
    float timer = 0;

    int price;

    int priceDefaultKangkung = 100;
    int priceDefaultPokChoi = 100;
    int priceDefaultSelada = 100;

    float timerDefaultKangkung = 200 * GlobalVariable.pupukBuff / 100;
    float timerStateKangkung2 = 100 * GlobalVariable.pupukBuff / 100;
    float timerStateKangkung3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultPokChoi = 200 * GlobalVariable.pupukBuff / 100;
    float timerStatePokChoi2 = 100 * GlobalVariable.pupukBuff / 100;
    float timerStatePokChoi3 = 1 * GlobalVariable.pupukBuff / 100;

    float timerDefaultSelada = 200 * GlobalVariable.pupukBuff / 100;
    float timerStateSelada2 = 100 * GlobalVariable.pupukBuff / 100;
    float timerStateSelada3 = 1 * GlobalVariable.pupukBuff / 100;

    int timerDefault;

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
        //timerDefaultKangkung = timerDefaultKangkung * GlobalVariable.pupukBuff / 100;
        //timerStateKangkung2 = timerStateKangkung2 * GlobalVariable.pupukBuff / 100;
        //timerStateKangkung3 = timerStateKangkung3 * GlobalVariable.pupukBuff / 100;
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        NetPotSprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        NetPotChoices = transform.parent.gameObject.transform.GetChild(4).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(8).gameObject;                   
        timerText = transform.parent.gameObject.transform.GetChild(6).gameObject;
        timerBG = transform.parent.gameObject.transform.GetChild(5).gameObject;
        gloves = transform.parent.gameObject.transform.GetChild(7).gameObject;
        NetPot = this.transform.parent.GetComponent<Button>();
        //Debug.Log("PotArray " + "Pot" + Pot);
        //Debug.Log("Haskey " + PlayerPrefs.HasKey("State" + Pot));
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
        Buy();
    }
    public void PlantPokchoi()
    {
        occupier = "Pokchoi";
        timer = timerDefaultPokChoi;
        price = priceDefaultPokChoi;
        Buy();
    }
    public void PlantSelada()
    {
        occupier = "Selada"; //set selada here jadi kode dibawah tau kalau occupier sudah jadi selada 
        timer = timerDefaultSelada;
        price = priceDefaultSelada;
        Buy();
    }

  
    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("Pot"+Pot, occupier);
            PlayerPrefs.SetFloat("Timer"+Pot, timer);
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
            //Debug.Log("Not Enugh Gold");
            Alert.ShowAlert("Gold Tidak cukup!");
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State"+Pot);
        timer = PlayerPrefs.GetFloat("Timer"+Pot);
        occupier = PlayerPrefs.GetString("Pot"+Pot);
        //Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        NetPotSprite.GetComponent<Image>().enabled = true;
        timerBG.SetActive(true);
        timerText.SetActive(true);
        NetPot.interactable = false;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0}:{1:00}", minutes, seconds);
        if (timer == 0){
            int zero = 0;
            timerText.GetComponent<TextMeshProUGUI>().text = zero.ToString();
        }
        /*There�s a couple of possibilities you have with the formats here: 
         * {0:#.00} would give you something like 3.00 or 10.12 or 123.45. 
         * For stuff like scores, you might want something like {0:00000} which would give you 00001 or 02523 or 20000 (or 2000000 if that�s your score :wink: ). 
         * Basically, the formatting part allows any kind of formatting (so you can also use this to format date times and other complex types). 
         * Basically, this means {indexOfParameter:formatting}.*/
        timerText.GetComponent<TextMeshProUGUI>().text = niceTime;
        if (occupier == "Kangkung")
        {
            if (timer <= timerStateKangkung3)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Kangkung_3");
            }
            else if (timer <= timerStateKangkung2)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Kangkung_2");
            }
            else
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Kangkung_1");
            }
        }
        else if(occupier == "Pokchoi") //correct spelling?
        {
            if (timer <= timerStatePokChoi3)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Pokchoi_3");
            }
            else if (timer <= timerStatePokChoi2)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Pokchoi_2");
            }
            else
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Pokchoi_1");
            }
        }
        else if(occupier == "Selada")
        {
            if (timer <= timerStateSelada3)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Selada_3");
            }
            else if (timer <= timerStateSelada2)
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Selada_2");
            }
            else
            {
                NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/Sayur_Selada_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State"+Pot, state);
        PlayerPrefs.SetFloat("Timer"+Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            int zero = 0;
            timerText.GetComponent<TextMeshProUGUI>().text = zero.ToString();
            harvestButton.SetActive(true);
            gloves.SetActive(true);
            CancelInvoke("Planting");
        }

        //Debug.Log("Timer: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("Timer" + Pot);
        NetPot.interactable = true;

        if (timer <= 0)
        {
            //Debug.Log("Timer State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
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
            //Debug.Log("Blom bisa di harvest. State: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("Pot" + Pot);
        NetPotSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/tanaman/placeholder");
        timerText.SetActive(false);
        timerBG.SetActive(false);
        gloves.SetActive(false);
        //Debug.Log("Harvested!");
        Alert.ShowAlert("Harvested " + occupier + " x1");

    }

}


