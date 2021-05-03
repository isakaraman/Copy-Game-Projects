using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    blockCount blocker;

    public int MaxHit = 0;
    int hits = 0;

    public Sprite[] hitsprite;
    void Start()
    {
        blocker = FindObjectOfType<blockCount>();
        blocker.Countblockcounter();
        
    }

    void OnCollisionEnter2D(Collision2D colle)
    {
       
        if (colle.gameObject.tag=="ball")
        {
            hits++;
            if (hits>=MaxHit)
            {

                Destroy(gameObject);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = hitsprite[hits - 1];
            }
        }
    }
    void Update()
    {
        
    }
}
