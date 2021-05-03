using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sucode : MonoBehaviour
{
    public Sprite[] suAnimasyonu;
    SpriteRenderer spriteRenderer;
    int suSayaci = 0;
    float zaman = 0;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 0.04f)
        {
            spriteRenderer.sprite = suAnimasyonu[suSayaci++];
            if (suAnimasyonu.Length == suSayaci)
            {
                suSayaci = 0;
            }
            zaman = 0;
        }
    }
}