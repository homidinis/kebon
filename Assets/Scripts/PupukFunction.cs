using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupukFunction : MonoBehaviour
{
    // Start is called before the first frame 

    void Start()
    {
        
        int pupukState = PlayerPrefs.GetInt("PupukState");
        int pupukTime = PlayerPrefs.GetInt("PupukTime");
        int pupukBuff = PlayerPrefs.GetInt("PupukBuff");
        if(pupukState == 1)
        {
            InvokeRepeating("pupukTimer",0f,1f);
            GlobalVariable.pupukBuff = pupukBuff;
        } 
    }

    void pupukTimer()
    {

        int pupukState = PlayerPrefs.GetInt("PupukState");
        int pupukTime = PlayerPrefs.GetInt("PupukTime");
        int pupukBuff = PlayerPrefs.GetInt("PupukBuff");
        
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
            int jumlahPupuk = PlayerPrefs.GetInt("PupukA");
            if (jumlahPupuk > 0)
            {
                GlobalVariable.pupukBuff = 50;
                PlayerPrefs.SetInt("PupukState", 1);
                PlayerPrefs.SetInt("PupukTime", 60);
                PlayerPrefs.SetInt("PupukBuff", 50);
                PlayerPrefs.Save();
                Debug.Log("Pupuk used");
                int jumlahPupukUsed = jumlahPupuk - 1;
                PlayerPrefs.SetInt("PupukA",jumlahPupukUsed);
                Start();
            }
        }
    }
  
}
