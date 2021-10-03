using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    
    bool isGrounded;
    
    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float speed = 0f;

    [SerializeField]
    private float maxSpeed = 5f;

    [SerializeField]
    private float jumpSpeed = 5f;

    [SerializeField]
    private float acceleration = .1f;

    [SerializeField]
    private float deceleration = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
        if((Physics2D.Linecast(transform.position,groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))/* ||
            (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))*/)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.Play("player_jump");
        }
        
        if (Input.GetKey("d") && (speed <= maxSpeed))
        {
            speed += acceleration;
            //rb2d.AddForce(new Vector2(maxSpeed, rb2d.velocity.y));
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y); 
            
            if (isGrounded)
                animator.Play("player_run");
            
            spriteRenderer.flipX = false;
        }

        else if (Input.GetKey("a"))
        {

            //rb2d.AddForce(new Vector2(-maxSpeed, rb2d.velocity.y));
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y); 

            if (isGrounded)
                animator.Play("player_run");
            
            spriteRenderer.flipX = true;
        }

        else
        {
            animator.Play("player_idle");
            
            if (isGrounded)
                animator.Play("player_idle");
            
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); 
        }

        if (Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed); 
        }

    }
}