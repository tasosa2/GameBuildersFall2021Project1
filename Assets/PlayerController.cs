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
    private float maxSpeed = 8f;

    [SerializeField]
    private float jumpSpeed = 5f;

    [SerializeField]
    private float acceleration = .1f;

    [SerializeField]
    private float deceleration = .3f;

    [SerializeField]
    private float canJump = 0f;
    
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
        

        if (Input.GetKey("d"))
        {

            
            if (speed < 0)
            {
                speed += deceleration;
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

                if (isGrounded)
                    animator.Play("player_turn");

                spriteRenderer.flipX = true;
            }

            else if ((speed >= 0) && (speed < maxSpeed))
            {
                speed += acceleration;
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                if (isGrounded)
                    animator.Play("player_run");

                spriteRenderer.flipX = false;
            }

            else
            {
                speed = maxSpeed;
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

                if (isGrounded)
                    animator.Play("player_run");

                spriteRenderer.flipX = false;
            }
            

        }

        else if (Input.GetKey("a"))
        {
            
            if (speed > 0)
            {
                speed -= deceleration;
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

                if (isGrounded)
                    animator.Play("player_turn");

                spriteRenderer.flipX = false;
            }

            else if ((speed <= 0) && (speed > -maxSpeed)){
                speed -= acceleration;
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                if (isGrounded)
                    animator.Play("player_run");

                spriteRenderer.flipX = true;
            }

            else
            {
                speed = -maxSpeed;
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

                if (isGrounded)
                    animator.Play("player_run");

                spriteRenderer.flipX = true;
            }
            


        }

        else
        {
            speed = 0;
            
            if (isGrounded)
                animator.Play("player_idle");
            
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y); //(0, rb2d.velocity.y) then (speed, rb2d.velocity.y)
        }

        if (Input.GetKey("space") && isGrounded && (Time.time > canJump))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed); //(rb2d.velocity.x, jumpSpeed)

            
            canJump = Time.time + 1.5f;
            
        }

    }
}