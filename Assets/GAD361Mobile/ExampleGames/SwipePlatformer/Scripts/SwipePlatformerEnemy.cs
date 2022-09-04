using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePlatformerEnemy : Char2D
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(currentMovement * Time.deltaTime);
    }

}
