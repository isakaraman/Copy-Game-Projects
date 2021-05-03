using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class kontrol : MonoBehaviour
{
    Rigidbody2D fizik;

    int puan = 0;

    public Text puanText;

    gamecontrol oyunkontrol;

    bool oyunbitti = true;

    AudioSource ses;

    public AudioClip carpmasesi;

    int enYuksekPuan = 0;
    
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        oyunkontrol = GameObject.FindGameObjectWithTag("GameController").GetComponent<gamecontrol>();
        ses = GetComponent<AudioSource>();

        enYuksekPuan = PlayerPrefs.GetInt("kayit");

        Debug.Log("enyüksekpuan "+enYuksekPuan);
    }

    
    void Update()
    {
        hareket();
    }

    void hareket()
    {
        if (fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        if (Input.GetMouseButtonDown(0)&&oyunbitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 200));
            ses.Play();
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="puan")
        {
            puan++;
            puanText.text = "Score: " + puan;
           
        }
        if (col.gameObject.tag=="kolon1")
        {
            oyunbitti = false;
            ses.clip = carpmasesi;
            ses.Play();
            oyunkontrol.oyunBitti();

            if (puan>enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("kayit", enYuksekPuan);

                
            }
            Invoke("anaMenuyeDon", 2);
        }
       
        }
         void anaMenuyeDon()
        {
        PlayerPrefs.SetInt("puanKayit", puan);
            SceneManager.LoadScene("ana menu");
    }
}
