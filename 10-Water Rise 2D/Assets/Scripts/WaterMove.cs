using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public float yMove = 0.2f;
    
    void Update()
    {
        float verticalMove = yMove * Time.deltaTime;
        transform.Translate(new Vector2(0f,verticalMove));
    }
}
