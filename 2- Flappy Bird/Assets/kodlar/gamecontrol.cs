using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontrol : MonoBehaviour
{

    public GameObject skyBir;
    public GameObject skyIki;
    public float arkaPlanHizi = -1.5f;

    Rigidbody2D fizikBir;
    Rigidbody2D fizikIki;

    public GameObject engel;
    public int kacAdetEngel;
    GameObject[] engeller;

    bool yoket = true;


    float uzunluk = 0;

    float degisimZamani = 0;
    int sayac = 0;
    void Start()
    {
        fizikBir = skyBir.GetComponent<Rigidbody2D>();
        fizikIki = skyIki.GetComponent<Rigidbody2D>();

        fizikBir.velocity = new Vector2(arkaPlanHizi, 0);
        fizikIki.velocity = new Vector2(arkaPlanHizi, 0);
        uzunluk = skyBir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kacAdetEngel];
        for (int i = 0; i <engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(arkaPlanHizi, 0);
        }
    
    
    }
    void Update()
    {
        if (yoket)
        {
         if (skyBir.transform.position.x<=-uzunluk)
        {
            skyBir.transform.position += new Vector3(uzunluk*2,0);
        }
        if (skyIki.transform.position.x<=-uzunluk)
        {
            skyIki.transform.position += new Vector3(uzunluk * 2, 0);
        }

        degisimZamani += Time.deltaTime;
        if (degisimZamani>2f)
        {
            degisimZamani = 0;
        
        float yEkseni = Random.Range(-5.96f, -3.41f);
        engeller[sayac].transform.position = new Vector3(11.26f, yEkseni);
            sayac++;
            if (sayac>=engeller.Length)
        {
            sayac = 0;
        }
        }
      
    }

    }

    public void oyunBitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizikIki.velocity = Vector2.zero;
            fizikBir.velocity = Vector2.zero;
        }

        yoket = false;
    }
}