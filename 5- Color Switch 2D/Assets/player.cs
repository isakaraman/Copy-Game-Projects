using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jumpValue = 10f;

    public Rigidbody2D physic;
    public SpriteRenderer collor;

    public Color colorMagenta;
    public Color colorYellow;
    public Color colorCyan;
    public Color colorPink;

    private string colorCurrent;
    private bool gameOver=false;

    public AudioSource colorChanger;
    public AudioSource colorDown;

    public GameObject circlePrefab;
    public GameObject circle2Prefab;
    public GameObject colorChangePrafab;

    public Transform lastCircle;

    public ParticleSystem ps;
    private Color currentColorer;


    void Start()
    {
        colorChange();

        var main = ps.main;
        main.startColor = currentColorer;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)&&!gameOver)
        {
            physic.velocity = Vector2.up * jumpValue;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="ColorChange")
        {
            Instan();
            colorChange();
            
            Destroy(col.gameObject);
            colorChanger.Play();

            var main = ps.main;
            main.startColor = currentColorer;
            return;
        }
        if (col.tag!=colorCurrent && !gameOver)
        {
            colorDown.Play();
            gameOver = true;
            Invoke("Restart", 1);
        }
    }
    void Instan()
    {
        GameObject prefabCircle;
        Transform colorChangey;

        int a = Random.Range(0, 4);

        if (a == 0)
        {
            prefabCircle = circle2Prefab;
        }
        else
        {
            prefabCircle = circlePrefab;
        }


        if (lastCircle.gameObject.tag.Equals("CircleOne"))
        {
            colorChangey = Instantiate(colorChangePrafab, new Vector2(0, lastCircle.position.y + 4), Quaternion.identity).transform;

            if (prefabCircle.tag.Equals("CircleOne"))
            {
                lastCircle = Instantiate(prefabCircle, new Vector2(0, colorChangey.position.y + 4), Quaternion.identity).transform;
            }
            else
            {
                lastCircle = Instantiate(prefabCircle, new Vector2(0, colorChangey.position.y + 5), Quaternion.identity).transform;
            }
        }
        else
        {
            colorChangey = Instantiate(colorChangePrafab, new Vector2(0, lastCircle.position.y + 5), Quaternion.identity).transform;

            if (prefabCircle.tag.Equals("CircleOne"))
            {
                lastCircle = Instantiate(prefabCircle, new Vector2(0, colorChangey.position.y + 4), Quaternion.identity).transform;
            }
            else
            {
                lastCircle = Instantiate(prefabCircle, new Vector2(0, colorChangey.position.y + 5), Quaternion.identity).transform;
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void colorChange()
    {
        int colorRandom = Random.Range(0, 4);

        switch (colorRandom)
        {
            case 0:
                collor.color = colorMagenta;
                colorCurrent ="MagentaTag";
                currentColorer = colorMagenta;
                break;
            case 1:
                collor.color = colorCyan;
                colorCurrent = "CyanTag";
                currentColorer = colorCyan;
                break;
            case 2:
                collor.color = colorPink;
                colorCurrent = "PinkTag";
                currentColorer = colorPink;
                break;
            case 3:
                collor.color = colorYellow;
                colorCurrent = "YellowTag";
                currentColorer = colorYellow;
                break;
        }
    }


   
}
