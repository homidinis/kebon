using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupukIndikator : MonoBehaviour
{
    public GameObject indikatorObj;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVariable.pupukBuff != 100)
        {
            indikatorObj.SetActive(true);
        }
        else if (GlobalVariable.pupukBuff == 100)
        {
            indikatorObj.SetActive(false);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
