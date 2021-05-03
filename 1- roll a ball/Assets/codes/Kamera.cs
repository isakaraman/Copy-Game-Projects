using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    Vector3 mesafe;
    public GameObject top;
    void Start()
    {
        mesafe = transform.position - top.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = top.transform.position + mesafe; 
    }
}
