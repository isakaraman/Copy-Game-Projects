using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCount : MonoBehaviour
{
    public int blockcounter;

    SceneLoader sceneLoader;


    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void Countblockcounter()
    {
        blockcounter++;
    }
    public void blockDestroyer()
    {
        blockcounter--;
        if (blockcounter<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
