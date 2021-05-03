using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anacember : MonoBehaviour
{
    public GameObject KucukCember;
    GameObject OyunYoneticisi;
    void Start()
    {
        OyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisitag");
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            kucukCemberOlustur();
        }
        
    }
    void kucukCemberOlustur()
    {
        Instantiate(KucukCember, transform.position, transform.rotation);
        OyunYoneticisi.GetComponent<oyunyoneticisikod>().KucukCemberlerdeTextGosterme();
    }
}
