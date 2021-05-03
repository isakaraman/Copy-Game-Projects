using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float shotcounter;
    public float winTimeBetweenShots = 0.2f;
    public float maxTimeBetweenShots = 3f;
    public GameObject protectile;
    public float protectileSpeed = 10f;


    private void Start()
    {
        shotcounter = Random.Range(winTimeBetweenShots, maxTimeBetweenShots);
    }
    private void Update()
    {
        CountDownAndShoot();
    }
    void CountDownAndShoot()
    {
        shotcounter -= Time.deltaTime;
        if (shotcounter<=0f)
        {
            Fire();
            shotcounter = Random.Range(winTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    void Fire()
    {
        //Vector2 laserPosition = new Vector2(transform.position.x, transform.position.y - 0.53f);
        var laser = Instantiate(protectile, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -protectileSpeed);
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

        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
