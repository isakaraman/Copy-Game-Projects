using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public float time = 0f;

    public int score = 10;
    public int CurrentScore = 0;
    public TextMeshProUGUI scoretext;


    void Awake()
    {
        int countGame = FindObjectsOfType<GameTime>().Length;
        if (countGame>1)
        {
            game5Object.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        
    }
    void Start()
    {
        scoretext.text = CurrentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = time;
    }
    public void gameScore()
    {
        CurrentScore += score;
        scoretext.text ="Skorun: " + CurrentScore.ToString();
    }
    public void resetGame()
    {
        Destroy(gameObject);
    }
}
