using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
            animator.Play("player_run");
            spriteRenderer.flipX = false;
        }

        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
            animator.Play("player_run");
            spriteRenderer.flipX = true;
        }

        else
        {
            animator.Play("player_idle");
        }

        if (Input.GetKey("space"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 3);
            animator.Play("player_jump");
        }

    }
}