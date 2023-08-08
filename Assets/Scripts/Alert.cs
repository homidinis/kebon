using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Alert : MonoBehaviour
{
    public static void ShowAlert(string message)
    {
        GameObject AlertPanel = GameObject.Find("Canvas").transform.Find("AlertPanel").gameObject;
        AlertPanel.SetActive(true);
        TextMeshProUGUI AlertDesc = GameObject.Find("AlertDesc").GetComponent<TextMeshProUGUI>();
        AlertDesc.text = message;

    }
}