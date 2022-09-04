using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    
    public GameObject characterPrefab;
    public Text chancetext;
    
   public int chance ; 
   
    bool isGrounded = true;
    Rigidbody2D rb2d;
    public float jumpheight = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        chance = 5;
       
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPosition.x < 0 )
        {
            Debug.Log("You are off screen");
            Destroy(characterPrefab);
            ((Manager2)(Manager2.instance)).GameOver();
        }
        if(Input.touchCount>0 && isGrounded)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
            touchposition.z = 0.0f;
            Debug.Log("Tapped");
            Jump();
            
        }
        float height = transform.position.y;
        if(height < -11.0f)
        {
            Debug.Log("falling");
            Destroy(characterPrefab);
          ((Manager2)(Manager2.instance)).GameOver();
        }
        chancetext.text = "Chance" + ":" +  chance;
        
    }
    void Jump()
    {
        if(rb2d != null  )
        {
            rb2d.velocity += Vector2.up * jumpheight;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; 
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "HardWall")
        {
        chance -= 1;
        Debug.Log("chances -1");
        
        if (chance == 0)
        {
            Debug.Log("Game Over");
        Destroy(characterPrefab);
        
        ((Manager2)(Manager2.instance)).gameover();
        }
      }
    }
   
}
