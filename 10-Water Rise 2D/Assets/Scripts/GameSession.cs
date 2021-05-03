using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    public int health = 3;
    public int score = 0;

    public Text healthText;
    public Text scoreText;


    private void Awake()
    {
        int objectNumb = FindObjectsOfType<GameSession>().Length;

        if (objectNumb > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        healthText.text = health.ToString();
        scoreText.text = score.ToString();
    }


    public void AddScore(int scoreAdding)
    {
        score += scoreAdding;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (health>=1)
        {
            health--;
            int currenScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currenScene);

            score = 0;
            healthText.text = health.ToString();


        }
        else
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}

