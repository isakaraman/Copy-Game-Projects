using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canver : MonoBehaviour
{
    public Sprite []animasyonKontrol;
    SpriteRenderer sprtrender;
    float zaman = 0;
    int animasyonSayac = 0;

    void Start()
    {
        sprtrender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 0.1f)
        {
            sprtrender.sprite = animasyonKontrol[animasyonSayac++];
            if (animasyonKontrol.Length==animasyonSayac)
            {
                animasyonSayac =0;
            }
            zaman = 0;
        }
    }
}
