using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public int Pot;
    string[] PotArray = {"Pot1","Pot2","Pot3","Pot4"}; //put pots in an array
    string[] StateArray = {"StatePot1","StatePot2","StatePot3","StatePot4"};
    string[] TimerArray = {"TimerPot1","TimerPot2","TimerPot3","TimerPot4"};
    // Start is called before the first frame update
    void Start()
    { 
        string StateArrayKey = StateArray[Pot];
        int state = PlayerPrefs.GetInt(StateArrayKey);
        
        string TimerArrayKey = TimerArray[Pot];
        int timer = PlayerPrefs.GetInt(TimerArrayKey);
        PlayerPrefs.DeleteKey(PotArray[Pot]);
        PlayerPrefs.DeleteKey(StateArray[Pot]);
        PlayerPrefs.DeleteKey(TimerArray[Pot]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
