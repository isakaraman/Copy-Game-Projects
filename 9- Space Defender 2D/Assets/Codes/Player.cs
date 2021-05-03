using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100;

    public float moveSpeed=0;
    public float padding = 0;

    float minX;
    float maxX;
    float minY;
    float maxY;

    public GameObject lazer;
    void Start()
    {
        playerBounderies();
    }

    
    void Update()
    {
        playerMove();
        playerFire();
    }
    void playerMove()
    {
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime* moveSpeed;
        var deltaY = Input.GetAxis("Vertical")*Time.deltaTime* moveSpeed;

        var moveX = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        var moveY = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);

        transform.position = new Vector2(moveX, moveY);
    }
    void playerBounderies()
    {
        Camera getCamera = Camera.main;

        minX = getCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        maxX = getCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        minY = getCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        maxY = getCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }
    void playerFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject laserObj = Instantiate(lazer, transform.position, Quaternion.identity);
            laserObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10); 
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        DamageDealer damageDealer = col.gameObject.GetComponent<DamageDealer>();


        damageDealer.Hit();

        ProcessHit(damageDealer);



    }

    void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
