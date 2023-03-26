using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantKangkung : MonoBehaviour
{
    int state = 0;
    int defaultTimerValue = 5; //change it here
    public int Pot;
    string[] PotArray = {"Pot1","Pot2","Pot3","Pot4"}; //put pots in an array
    
    GameObject childImage;
    GameObject childButton;

    // Start is called before the first frame update
    void Start()
    {
        childImage = this.transform.GetChild(0).gameObject;  //get first child, etc
        childButton = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Planting(int nomor_talang)
    {
        
        nomor_talang = Pot;

        string plantingSpot = PotArray[nomor_talang];
         if (PlayerPrefs.HasKey(plantingSpot)) //kalau plantingSpot udah ada tanaman, do nothing
        {

        }
        else
        {

            PlayerPrefs.SetString(plantingSpot,"Kangkung"); //pot-sekian udah ada kangkungnya

            int gold = PlayerPrefs.GetInt("Gold");
            if(gold > 50) //kalau gold >50 boleh
            { 
                state++;
                if(state == 1)
                {
                    childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
                    this.GetComponent<Button>().interactable = false;
                    InvokeRepeating("PlantProgress",0f,1f);
                }
            }
            else
            {
            state = 0;  
            TextMeshPro tmp_text = GetComponent<TextMeshPro>();
            tmp_text.enabled = true;
            tmp_text.CrossFadeAlpha(0.0f, 0.05f, false);
            tmp_text.enabled = false;
            }
    }
    }

    void PlantProgress()
    {
        int timer = defaultTimerValue;
        timer --;
        if(state == 1 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
            // timer = 2;
        }

        if(state == 2 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
            childButton.SetActive(true);
        }
        if(state == 2 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/kkk");
            childButton.SetActive(true);
        }
    }

    public void Harvest()
    {
        
        int timer = defaultTimerValue;
        state = 0;
        this.GetComponent<Button>().interactable = true;
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
        childButton.SetActive(false);

        CancelInvoke("PlantProgress");
        timer = defaultTimerValue;

        int lastKangkung = PlayerPrefs.GetInt("Kangkung");
        PlayerPrefs.SetInt("Kangkung", lastKangkung+1); //increment inventory
        // PlayerPrefs.SetInt("Gold", lastGold+20); <- dapet gold saat menjual, pindah ke Rumah nanti
        PlayerPrefs.Save();
    }
    // PlayerPrefs.Save(); call this on scene exit
}
