using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonEnabler : MonoBehaviour
{
    public int Pot;
    string[] PotArray = {"Pot1","Pot2","Pot3","Pot4"}; //put pots in an array
    string[] StateArray = {"StatePot1","StatePot2","StatePot3","StatePot4"};
    string[] TimerArray = {"TimerPot1","TimerPot2","TimerPot3","TimerPot4"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonEnabler(int Pot)
    {
        
        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);

        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);

        GameObject netpot = GameObject.Find("Netpot_1");
        if(state >= 1)
        {
            netpot.SetActive(false);
        }
        else if (state == 0)
        {
            netpot.SetActive(true);
        }
    }
//netpot 1 setactive false if timer ==0 and state == 2 enable
}
