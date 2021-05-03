using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ballCode : MonoBehaviour
{
    [SerializeField] private GameObject paddle;
    public AudioClip[] sounds;
  


    Vector2 distance;

    blockCount blockcounter;
    GameTime gametime;

    bool started = false;


    void Start()
    {
        distance = transform.position - paddle.transform.position;
        blockcounter = FindObjectOfType<blockCount>();
        gametime = FindObjectOfType<GameTime>();
    }


    void Update()
    {
        if (!started)
        {
            ballStart();
        }
        ballForce();
    }

    void ballStart()
    {
        Vector2 vec = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = vec + distance;
    }
    void ballForce()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 15);
            started = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "block")
        {
            blockcounter.blockDestroyer();

            AudioClip audios = sounds[Random.Range(0,sounds.Length)];

            GetComponent<AudioSource>().PlayOneShot(audios);

            gametime.gameScore();

            Destroy(col.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag == "GameOver")
        {
           
            SceneManager.LoadScene("Win Screen");
        }
    }
}