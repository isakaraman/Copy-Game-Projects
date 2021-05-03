using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScripts : MonoBehaviour
{
    public AudioClip coinSound;

    int point = 100;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(coinSound,Camera.main.transform.position);

        FindObjectOfType<GameSession>().AddScore(point);

        Destroy(gameObject);


    }
}
