using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altıncode : MonoBehaviour
{
    public Sprite[] altınlar;
    SpriteRenderer spriteRenderer;
    float zaman = 0;
    int animasyonSayac = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 0.04f)
        {
            spriteRenderer.sprite = altınlar[animasyonSayac++];
            if (altınlar.Length == animasyonSayac)
            {
                animasyonSayac = 0;
            }
            zaman = 0;
        }
    }
}
