using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  



public class SceneMover: MonoBehaviour
{  
    public void Home() {  
        SceneManager.LoadScene("Home");  
    }  
    public void Kebun_Tanah() {  
        SceneManager.LoadScene("Kebun_Tanah");  
    }  
    public void Greenhouse() {  
        SceneManager.LoadScene("Greenhouse");  
    }
    public void Rumah_Masak()
    {
        SceneManager.LoadScene("rumah_masak");
    }
}