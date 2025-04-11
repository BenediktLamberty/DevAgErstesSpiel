using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animation;
    private PlayerModel playerModel;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        playerModel = gameObject.GetComponent<PlayerModel>();
    }

    void FixedUpdate()
    {
        if (playerModel.IsDead)
        {
            return;
        }

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * playerModel.MoveSpeed, rb.velocity.y);
    }

    void Update()
    {
        if (playerModel.IsDead)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && playerModel.IsGrounded)
        {
            rb.velocity = Vector2.up * playerModel.JumpForce;
            
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            playerModel.Health = 0;
        }
        if (collision.gameObject.tag == "Ground")
        {
            playerModel.IsGrounded = true;
            animation.SetBool("isJumping", false);
        }
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerModel.IsGrounded = false;
            animation.SetBool("isJumping", true);
        }
    }

}
