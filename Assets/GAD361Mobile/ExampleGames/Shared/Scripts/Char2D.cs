using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2D : MonoBehaviour
{
    public bool facingRight = true;
    public float moveSpeed = 1.0f;
    protected SpriteRenderer spriterenderer;
    protected Vector2 currentMovement;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    protected void Init()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovement(Vector2 movement)
    {
        //Handle cases where we are changing direction
        if (movement.x < 0 && facingRight)
        {
            Flip();
        }
        else if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        currentMovement = movement * moveSpeed;
    }

    public void Flip()
    {
        facingRight = !facingRight;
        if (!facingRight)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
    }
}
