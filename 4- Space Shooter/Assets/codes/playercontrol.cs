using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float karakterHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    float atesZamani = 0;
    public float atesGecenSure;
    public GameObject kursun;
    public Transform kursunNeredenCiksin;
    
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
       
    }
    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>atesZamani)
        {
            atesZamani = Time.time + atesGecenSure;
            Instantiate(kursun, kursunNeredenCiksin.position, Quaternion.identity);
        }
    }
    
    void FixedUpdate()
    {
         horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical);
        fizik.velocity = vec*karakterHiz;
        fizik.position = new Vector3(
            Mathf.Clamp(fizik.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ));
        
    }
}
