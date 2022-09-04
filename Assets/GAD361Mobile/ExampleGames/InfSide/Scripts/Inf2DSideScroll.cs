using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inf2DSideScroll : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    float scrollDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = scrollSpeed * Time.fixedDeltaTime; //how far are we going to scroll each thing?
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.position += (Vector3)(-Vector2.right * dist); //move the objects
        }
        scrollDistance += dist; //update the total distance scrolled.
        ((Inf2DSideManager)(Inf2DSideManager.instance)).UpdateScoreText(scrollDistance);
    }

    public float DistanceScrolled()
    {
        return scrollDistance;
    }
}
