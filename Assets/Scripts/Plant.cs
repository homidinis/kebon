using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    int state = 0;
    int timer = 5;
    GameObject childImage;
    GameObject childButton;
    // Start is called before the first frame update
    void Start()
    {
        childImage = this.transform.GetChild(0).gameObject;
        childButton = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Planting()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        if(gold >50)
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
            // g bole
        }
    }

    void PlantProgress()
    {
        timer --;
        if(state == 1 && timer <= 0)
        {
            state ++;
            childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
            timer = 3;
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
        state = 0;
        this.GetComponent<Button>().interactable = true;
        childImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Tile");
        childButton.SetActive(false);
        
        CancelInvoke("PlantProgress");
        timer = 5;

        int lastKangkung = PlayerPrefs.GetInt("Kangkung");
        PlayerPrefs.SetInt("Kangkung", lastKangkung+1);
        PlayerPrefs.Save();
    }
}
