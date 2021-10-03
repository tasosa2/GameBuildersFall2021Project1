using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAISideMovement : MonoBehaviour
{
    public float speed = 1f;
    public bool onGround = false;


    public Rigidbody2D RB;
    public Collider2D Col;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>(); // needed for movement, since we are using the function .velocity on the rigidboy to create movement.
        Col = GetComponent<Collider2D>();//find collider attach to the object, in this case the goomba
    }

    private void OnTriggerEnter2D()
    {  //Sent when another object enters a trigger collider attached to this object (2D physics only).

        Debug.Log("GO other Way // Speed: ");
        Debug.Log(speed);

        speed = -speed; // invert the direction of the goomba
    }

    // Update is called once per frame
    void Update()
    {

        RB.velocity = new Vector2(-speed, RB.velocity.y);    // manages the direction and speed of the goomba, constant velocity on either direction.

    }
}
