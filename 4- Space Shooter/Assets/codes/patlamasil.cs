using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patlamasil : MonoBehaviour
{
    public float silinmezamani;
    void Start()
    {
        Destroy(gameObject, silinmezamani);
    }

    
}
