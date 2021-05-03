using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursunKontrol : MonoBehaviour
{
    maceKontrol dusman;
    Rigidbody2D fizik;
    void Start()
    {
        dusman = GameObject.FindGameObjectWithTag("mace").GetComponent<maceKontrol>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(dusman.getYon()*1000);
    }

    
    void Update()
    {
        
    }
}
