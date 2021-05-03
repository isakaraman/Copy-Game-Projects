using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCode : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        float paddlePos = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 14 + 1,1.1f,14.9f);

        Vector2 vec = new Vector2(paddlePos, transform.position.y);

        transform.position = vec;
    }
}
