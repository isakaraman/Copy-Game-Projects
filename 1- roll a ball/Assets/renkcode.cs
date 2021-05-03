using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class renkcode : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void butonSec(int gelenButon)
    {
        if (gelenButon==1)
        {
            SceneManager.LoadScene("anamenu"); 
        }
    }
}
