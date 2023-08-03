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
    public void Kebun_Tanah_2()
    {
        SceneManager.LoadScene("Kebun_Tanah_2");
    }
    public void Dapur()
    {
        SceneManager.LoadScene("rumah_masak");
    }
    public void RuangTamu()
    {
        SceneManager.LoadScene("rumah_komputer");
    }
    public void Rumah_Pupuk()
    {
        SceneManager.LoadScene("rumah_pupuk");
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void Library()
    {
        SceneManager.LoadScene("Library");
    }
    public void Sawah()
    {
        SceneManager.LoadScene("Sawah");
    }
    public void Start()
    {
        SceneManager.LoadScene("StartScreen");
    }


}