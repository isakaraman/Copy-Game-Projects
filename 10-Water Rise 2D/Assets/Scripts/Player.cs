using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 0f;
    public float jumpSpeed = 0f;
    public float climbSpeed = 5f;
    bool isAlive = true;
    Rigidbody2D rigid;
    Animator animat;
    BoxCollider2D boxcolli;

    CapsuleCollider2D capsulcolider;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
        boxcolli = GetComponent<BoxCollider2D>();
        capsulcolider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        Die();
        if (isAlive)
        {

            Run();
            jump();
            Climbing();
        }
    }
    void Run()
    {
        float xMove = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(xMove * runSpeed, rigid.velocity.y);

        rigid.velocity = playerVelocity;

        bool isHorizontalSpeed = Mathf.Abs(rigid.velocity.x) > Mathf.Epsilon;
        animat.SetBool("Running", isHorizontalSpeed);
    }
    void jump()
    {
        if (boxcolli.IsTouchingLayers(LayerMask.GetMask("foreground")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                rigid.velocity += jumpVelocity;
            }
        }
    }
    void Climbing()
    {
        if (boxcolli.IsTouchingLayers(LayerMask.GetMask("climb")))
        {
            float yMove = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(rigid.velocity.x,yMove* climbSpeed);
            rigid.velocity = climbVelocity;
            rigid.gravityScale = 0f;

            bool isHorizontalSpeed = Mathf.Abs(rigid.velocity.x) > Mathf.Epsilon;
            animat.SetBool("Climbing", isHorizontalSpeed);
        }
        else
        {
            animat.SetBool("Climbing", false);
            rigid.gravityScale = 1f;
        }
    }
    void Die()
    {
        if (capsulcolider.IsTouchingLayers(LayerMask.GetMask("water","enemy")))
        {
            isAlive = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
