using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;


//This class inherits from Char2D, which gives basic movement calculations.
public class SwipePlatformerPlayer : Char2D
{
    public float jumpPower = 1.0f;
    bool grounded;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        base.Init();
        rb2d = GetComponent<Rigidbody2D>();
        MobileControls.OnSwipe += OnSwipe;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //In the physics loop, set current velocity (preserve gravity)
        rb2d.velocity = new Vector2(currentMovement.x, rb2d.velocity.y );
    }

    void Jump()
    {
        if (grounded && rb2d!=null)
        {
            grounded = false;
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnSwipe(SwipeData swipe)
    {
        if (swipe.dir == Direction.Dir.UP)
        {
            //Debug.Log("UP");
            Jump();
        }
        else if (swipe.dir == Direction.Dir.LEFT)
        {
            //Debug.Log("LEFT");
            SetMovement(-Vector2.right);
        }
        else if (swipe.dir == Direction.Dir.RIGHT)
        {
            //Debug.Log("Right");
            SetMovement(Vector2.right);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Enemies are tagged "Respawn"
        if (col.tag == "Respawn")
        {
            ((SwipePlatformerManager)(SwipePlatformerManager.instance)).GameOver();
        } //collectables are tagged "GameController"
        else if (col.tag == "GameController")
        {
            //Destroy the coin then add score
            Destroy(col.gameObject);
            ((SwipePlatformerManager)(SwipePlatformerManager.instance)).AddScore(1);
        }
        else //it must be the ground
            grounded = true;
    }
}
