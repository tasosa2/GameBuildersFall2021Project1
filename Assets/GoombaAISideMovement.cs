using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAISideMovement : MonoBehaviour{
    public float speed= 1f;
    public bool onGround = false;
   

    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start(){
        RB = GetComponent<Rigidbody2D>(); // needed for movement
    }

    // Update is called once per frame
    void Update(){
        Vector2 Movement = new Vector2(0f, 0f);
        //Ray2D Ray = Physics2D.Raycast();

        RB.velocity = new Vector2(-speed, RB.velocity.y);    // manages the direction and speed of the goomba 

    }
}
