using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;

public class Inf2DSideCharacter : MonoBehaviour
{
    bool grounded;
    Rigidbody2D rb2d;
    public float jumpPower = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        MobileControls.OnTap += OnTap;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTap(Vector2 tappos)
    {
        Debug.Log("Tapped");
        if (grounded && rb2d != null)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb2d.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        grounded = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Enemies are tagged with 'respawn'
        if (col.tag == "Respawn")
        {
            ((Inf2DSideManager)(Inf2DSideManager.instance)).GameOver();
        }
        else
        {
            Debug.Log("Collided with " + col.name);
            grounded = true;
        }
    }
}
