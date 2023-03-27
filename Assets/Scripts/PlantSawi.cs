using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSawi : MonoBehaviour
{
   
    int state = 0;
    int defaultTimerValue = 5; //change it here

    GameObject childImage;
    GameObject childButton;

    // Start is called before the first frame update
    void Start()
    {
        childImage = this.transform.GetChild(0).gameObject;  //get first child, etc
        childButton = this.transform.GetChild(1).gameObject;
         PlayerPrefs.SetInt("Gold",500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Planting()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if(gold > 50)
        {
            state++;
            if(state == 1)
            {
                childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_1");
                this.GetComponent<Button>().interactable = false;
                InvokeRepeating("PlantProgress",0f,1f);
            }
        }
        else
        {
          state = 0;  
        }
    }

    void PlantProgress()
    {
        
        int timer = defaultTimerValue;
        timer --;
        if(state == 1 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_1");
            // timer = 2;
        }

        if(state == 2 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_2");
            childButton.SetActive(true);
        }
        if(state == 2 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Sawi_3");
            childButton.SetActive(true);
        }
    }

    void Harvest()
    {
        int timer = defaultTimerValue;
        state = 0;
        this.GetComponent<Button>().interactable = true;
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
        childButton.SetActive(false);

        CancelInvoke("PlantProgress");
        timer = defaultTimerValue;

        int lastSawi = PlayerPrefs.GetInt("Sawi");
        PlayerPrefs.SetInt("Sawi", lastSawi+1); //increment inventory
        // PlayerPrefs.SetInt("Gold", lastGold+20); <- dapet gold saat menjual, pindah ke Rumah nanti
        PlayerPrefs.Save();
    }
}
