using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class anamenu : MonoBehaviour
{
    public Text skorText;
    public Text puanText;
    void Start()
    {
        int enYuksekSkor = PlayerPrefs.GetInt("kayit");
        int puan = PlayerPrefs.GetInt("puanKayit");
        skorText.text = "EN YÜKSEK SKOR: " + enYuksekSkor;
        puanText.text = "PUANIN: " + puan;
    }

   
    void Update()
    {
        
    }
    public void oyunaGit()
    {
        SceneManager.LoadScene("LevelBir");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }
}
