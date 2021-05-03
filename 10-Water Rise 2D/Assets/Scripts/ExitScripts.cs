using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitScripts : MonoBehaviour
{
    public float timeSlow = 0.2f;
    public float totalTime = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = timeSlow;

        yield return new WaitForSecondsRealtime(totalTime);

        Time.timeScale = 1f;

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }
}
