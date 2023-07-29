using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupukFunction : MonoBehaviour
{
    // Start is called before the first frame 

    int pupukState = PlayerPrefs.GetInt("PupukState");
    int pupukTime = PlayerPrefs.GetInt("PupukTime");
    int pupukBuff = PlayerPrefs.GetInt("PupukBuff");
    void Start()
    {
       if(pupukState == 1)
        {
            InvokeRepeating("pupukTimer",0f,1f);
            GlobalVariable.pupukBuff = pupukBuff;
        } 
    }

    void pupukTimer()
    {
        pupukTime--;
        if (pupukTime <= 0)
        {
            CancelInvoke("pupukTimer");
            GlobalVariable.pupukBuff = 0;
            PlayerPrefs.SetInt("PupukState", 0);
            PlayerPrefs.Save();
        }

    }

    public void UsePupuk(int pupukType)
    {
        if(pupukType == 1)
        {
            PlayerPrefs.SetInt("PupukState", 1);
            PlayerPrefs.SetInt("PupukTime", 3600);
            PlayerPrefs.SetInt("PupukBuff", 75);
            PlayerPrefs.Save();
            Start();
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
