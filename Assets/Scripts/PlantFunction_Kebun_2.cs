using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantFunction_Kebun_2 : MonoBehaviour
{
    public int Pot;

    int state = 0;
    int timer = 0;

    int price;

    int priceDefaultJambu = 50;
    int priceDefaultLengkeng = 100;
    int priceDefaultPepaya = 150;
    int priceDefaultRambutan = 150;
    int priceDefaultPisang = 150;

    int timerDefaultJambu = 10 * (GlobalVariable.pupukBuff / 100);

        int timerStateJambu2 = 5 * (GlobalVariable.pupukBuff / 100);
        int timerStateJambu3 = 1 * (GlobalVariable.pupukBuff / 100);

    int timerDefaultLengkeng = 10 * (GlobalVariable.pupukBuff / 100);
        int timerStateLengkeng2 = 5 * (GlobalVariable.pupukBuff / 100);
        int timerStateLengkeng3 = 1 * (GlobalVariable.pupukBuff / 100);

    int timerDefaultPepaya = 10 * (GlobalVariable.pupukBuff / 100);
        int timerStatePepaya2 = 5 * (GlobalVariable.pupukBuff / 100);
        int timerStatePepaya3 = 1 * (GlobalVariable.pupukBuff / 100);

    int timerDefaultRambutan = 10 * (GlobalVariable.pupukBuff / 100);
        int timerStateRambutan2 = 5 * (GlobalVariable.pupukBuff / 100);
        int timerStateRambutan3 = 1 * (GlobalVariable.pupukBuff / 100);

    int timerDefaultPisang = 10 * (GlobalVariable.pupukBuff / 100);
        int timerStatePisang2 = 5 * (GlobalVariable.pupukBuff / 100);
        int timerStatePisang3 = 1 * (GlobalVariable.pupukBuff / 100);    
    int timerDefault;

    //string[] PotArray = { "Pot1", "Pot2", "Pot3", "Pot4", "Pot5", "Pot6", "Pot7", "Pot8", "Pot9", "Pot10", "Pot11", "Pot12" }; //put pots in an array
    //string[] StateArray = { "StatePot1", "StatePot2", "StatePot3", "StatePot4", "StatePot5", "StatePot6", "StatePot7", "StatePot8", "StatePot9", "StatePot10", "StatePot11","StatePot12" };
    //string[] TimerArray = { "TimerPot1", "TimerPot2", "TimerPot3", "TimerPot4", "TimerPot5", "TimerPot6", "TimerPot7", "TimerPot8", "TimerPot9", "TimerPot10", "TimerPot3", "TimerPot3" };

    GameObject childImage;
    GameObject harvestButton;
    GameObject Plantspot2Choices;
    bool Plantspot2ChoicesBool = false;
    GameObject Plantspot2Sprite;

    string occupier;
    Button Plantspot2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Gold",5000);
        //childImage = GameObject.Find("kkk");  //get first child, etc
        childImage = transform.parent.gameObject.transform.GetChild(1).gameObject;
        Plantspot2Sprite = transform.parent.gameObject.transform.GetChild(3).gameObject;
        Plantspot2Choices = transform.parent.gameObject.transform.GetChild(5).gameObject;
        harvestButton = transform.parent.gameObject.transform.GetChild(4).gameObject;                        
        Plantspot2 = this.transform.parent.GetComponent<Button>();
        Debug.Log("PlantingSpotArray " + "PlantingSpot2" + Pot);
        Debug.Log("Haskey " + PlayerPrefs.HasKey("State_Kebun2" + Pot));
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
        timer = PlayerPrefs.GetInt("Timer_Kebun2"+Pot);


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
            Debug.Log("State_Kebun: " + state + "Planting at: " + plantingSpot);
            string occupier = PlayerPrefs.GetString(plantingSpot);
            Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier);
        }

    }

    public void Buy()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if (gold >= price)
        {
            PlayerPrefs.SetString("PlantingSpot2"+Pot, occupier);
            PlayerPrefs.SetInt("Timer_Kebun2"+Pot, timer);
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
        }
    }


    public void Planting()
    {
        state = PlayerPrefs.GetInt("State_Kebun2"+Pot);
        timer = PlayerPrefs.GetInt("Timer_Kebun2"+Pot);
        occupier = PlayerPrefs.GetString("PlantingSpot2"+Pot);
        Debug.Log("Occupier " + occupier);
        Debug.Log("Plant Progress Called. State " + state + " Timer " + timer);
        Plantspot2Sprite.GetComponent<Image>().enabled = true;

        if (occupier == "Jambu")
        {
            if (timer <= timerStateJambu3)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Jambu_3");
            }
            else if (timer <= timerStateJambu2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Jambu_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Jambu_1");
            }
        }
        else if(occupier == "Lengkeng") //correct spelling?
        {
            if (timer <= timerStateLengkeng3)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Lengkeng_3");
            }
            else if (timer <= timerStateLengkeng2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Lengkeng_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Lengkeng_1");
            }
        }
        else if(occupier == "Pepaya")
        {
            if (timer <= timerStatePepaya3)
            {   
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pepaya_3");
            }
            else if (timer <= timerStatePepaya2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pepaya_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pepaya_1");
            }

        }
        else if(occupier == "Rambutan")
        {
            if (timer <= timerStateRambutan3)
            {   
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Rambutan_3");
            }
            else if (timer <= timerStateRambutan2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Rambutan_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Rambutan_1");
            }

        }
        else if(occupier == "Pisang")
        {
            Debug.Log("Plating Pisang");
            if (timer <= timerStatePisang3)
            {   
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pisang_3");
            }
            else if (timer <= timerStatePisang2)
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pisang_2");
            }
            else
            {
                Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/Pohon_Pisang_1");
            }

        }

        timer--;
        PlayerPrefs.SetInt("State_Kebun2"+Pot, state);
        PlayerPrefs.SetInt("Timer_Kebun2"+Pot, timer);
        PlayerPrefs.Save();

        if (timer <= 0)
        {
            harvestButton.SetActive(true);
            CancelInvoke("Planting");
        }

        Debug.Log("Timer_Kebun2: " + timer + " State: " + state);
    }

    public void Harvest()
    {
        int timer = PlayerPrefs.GetInt("Timer_Kebun2"+Pot);
        Plantspot2.interactable = true;
        if (timer <= 0)
        {
            Debug.Log("Timer_Kebun2 State OK! Timer:" + timer + " State: " + state + " Occupier: " + occupier);
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
            Debug.Log("Blom bisa di harvest. State_Kebun2: " + state + "/4 dan Timer: " + timer + "/0");
        }

        PlayerPrefs.DeleteKey("PlantingSpot2"+Pot);
        Plantspot2Sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/placeholder");
        Debug.Log("Harvested " + occupier);
    }

    //public void Planting()
    //{

    //    //int state = 0;
    //    //int timer = timerDefault;

    //    //string plantingSpot = PotArray[Pot];

    //    //if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
    //    //{
    //    //    Debug.Log("Already planted here. State: " + state);
    //    //    Debug.Log("Di pot " + plantingSpot + " ini udah ada: " + occupier + " dengan state: " + state);
    //    //}
    //    //else
    //    //{
    //    //    int gold = PlayerPrefs.GetInt("Gold");

    //    //    if (gold > 50) 
    //    //    {
    //    //        PlayerPrefs.SetString(plantingSpot, occupier); //pot-sekian udah ada Jambunya
    //    //        state++;
    //    //        PlayerPrefs.SetInt(StateArray[Pot], state); //state = 1 state gamau increment?
    //    //        PlayerPrefs.SetInt(TimerArray[Pot], timerDefault);

    //    //        PlayerPrefs.Save();
    //    //        Debug.Log("Started planting with state: " + state + " Timer: " + timer);

    //    //        if (state == 1)
    //    //        {
    //    //            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Jambu_1");
    //    //            InvokeRepeating("PlantProgress", 0f, 1f);
    //    //        }
    //    //    }
    //    //    else
    //    //    {
    //    //        Debug.Log("Not enough money. State: " + state + "Uang sekarang: " + PlayerPrefs.GetInt("Gold"));
    //    //        // TextMeshPro tmp_text = GetComponent<TextMeshPro>();
    //    //        // tmp_text.enabled = true;
    //    //        // tmp_text.CrossFadeAlpha(0.0f, 0.05f, false);
    //    //        // tmp_text.enabled = false;
    //    //    }
    //    //}
    //}


}

//int lastGold = PlayerPrefs.GetInt("Gold");
//PlayerPrefs.SetInt("Gold", lastGold+20); //<- dapet gold saat menjual, pindah ke Rumah nanti
//PlayerPrefs.Save(); call this on scene exit

