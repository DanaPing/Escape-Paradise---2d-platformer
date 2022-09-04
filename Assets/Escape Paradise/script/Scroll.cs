using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject ball;
   
    public float scrollSpeed = 1.0f;
    float scrollDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        float distance = scrollSpeed * Time.fixedDeltaTime;
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child. position += (Vector3)(-Vector2.right*distance);

        }
        scrollDistance += distance;
       
        
    }
    public float DistanceScrolled ()
    {
        return scrollDistance;
    }
}
