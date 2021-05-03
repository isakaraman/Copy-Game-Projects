using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopHareket : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;

    int sayac = 0;
    int sayac2 = 3;
    public int puanSayisi;
    public Text sayacSayisi;
    public Text oyunBitti;
    public Text can;

    float anaMenuDon = 0;

    


    
    void Start()
    {
        Time.timeScale = 1;
        fizik = GetComponent<Rigidbody>();

        if (SceneManager.GetActiveScene().buildIndex> PlayerPrefs.GetInt("kacincilevel"))
        {
            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);
        }

        

    }

    void Update()
    {
        
        
    }
   
    void FixedUpdate()
    {
        float yatay = SimpleInput.GetAxisRaw("Horizontal");
        float dikey = SimpleInput.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(yatay, 0, dikey);
        fizik.AddForce(vec * hiz);

        if (sayac2 == 0)
        {
            Time.timeScale = 0.4f;
            oyunBitti.text = "OYUN BİTTİ";
            anaMenuDon += Time.deltaTime;
            if (anaMenuDon > 1)
            {
                SceneManager.LoadScene("anamenu");
            }

        }
        if (sayac == puanSayisi)
        {
            Time.timeScale = 0.4f;
            oyunBitti.text = "SEVİYE BİTTİ";
            anaMenuDon += Time.deltaTime;

            if (anaMenuDon > 1)
            {
                if (PlayerPrefs.GetInt("kacincilevel")==1)
                {
                  SceneManager.LoadScene("Level-2");
                }
                else if (PlayerPrefs.GetInt("kacincilevel") == 2)
                {
                    SceneManager.LoadScene("Level-3");
                }
                else if (PlayerPrefs.GetInt("kacincilevel") == 3)
                {
                    SceneManager.LoadScene("anamenu");
                }
                
                
              
            }
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "yokol")
        {
            Destroy(other.gameObject);
            sayac++;
            sayacSayisi.text = "Toplanan Küpler = "+sayac;
            
            
        }
        
        if (other.gameObject.tag=="Finish")
        {
            Destroy(other.gameObject);
            sayac2--;
            can.text = "Kalan Can = " + sayac2;
           
        }
        
    }
    }
