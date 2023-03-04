using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public bool isPlanted_K1 = false;
public bool isPlanted_K2 = false;
public bool isPlanted_K3 = false;
public bool isPlanted_K4 = false;
public int timer1 = 0;
public int timer2 = 0;
public int timer3 = 0;
public int timer4 = 0;
public class PlantGreenhouse : MonoBehaviour
{
    public void Tanam_talang1_lubang1() //is this efficient
    {
        
        isPlanted_K1 = true;
        PlayerPrefs.SetInt(Kangkung1, 1);
        //start time1

    }
     public void Tanam_talang1_lubang2()
    {
        isPlanted_K2 = true;
        PlayerPrefs.SetInt(Kangkung2, 1);

    }
     public void Tanam_talang1_lubang3()
    {
        isPlanted_K3 = true;
        PlayerPrefs.SetInt(Kangkung3, 1);

    }
     public void Tanam_talang1_lubang4()
    {
        isPlanted_K4 = true;
        PlayerPrefs.SetInt(Kangkung4, 1);

    }

 float timeLeft = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
string[] talang = {"1", "2", "3", "4"};
for (int i = 0; i < talang.Length; i++) 
{
  if(isPlanted_K+talang[i]){
    //timer1++;
    //      if time==10 set sprite to tunas
    //      if time = 25 set sprite to juvenile
     //      if time = 30 set sprite to adult
  }
}
        //if isPlanted = true
        // for (int i = 0; i < 5; i++) 
        // {
        //     timeIncrement();
        //      if time==10 set sprite to tunas
        //      if time = 25 set sprite to juvenile
        //      if time = 30 set sprite to adult
        // }
         timeLeft -= Time.deltaTime;
         if(timeLeft < 0)
         {
             GameOver();
         }
    }
}
