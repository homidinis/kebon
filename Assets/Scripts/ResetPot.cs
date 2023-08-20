using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All playerprefs deleted!");
    }
    public void AddGold()
    {
        int gold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", gold + 50);
        Debug.Log("Gold added! Current gold value: " + gold);
        Alert.ShowAlert("Mendapatkan 50 Gold!");
    }
}
