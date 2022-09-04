using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Patrol2D : MonoBehaviour
{
    public enum PatrolDir
    {
        RIGHT,
        LEFT,
        STOPPED
    }
    public float patrolStopDistRight = 1.0f;
    public float patrolStopDistLeft = 1.0f;
    public PatrolDir startDirection;
    Vector2 startPos;
    float travelledx = 0;
    Char2D character;
    PatrolDir currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Char2D>();   
        startPos = transform.position;
        currentDirection = startDirection;
    }

    // Update is called once per frame
    void Update()
    {
        MovementLogic();
    }

    void PatrolDirection(PatrolDir dir)
    {
        currentDirection = dir;
        if (currentDirection == PatrolDir.RIGHT)
            character.SetMovement(Vector2.right);
        if (currentDirection == PatrolDir.LEFT)
            character.SetMovement(-Vector2.right);
        if (currentDirection == PatrolDir.STOPPED)
        {
            character.SetMovement(Vector2.zero);
        }
    }

    void MovementLogic()
    {
        travelledx = transform.position.x - startPos.x; 
        if (currentDirection == PatrolDir.RIGHT)
        {
            if (travelledx > patrolStopDistRight)
            {
                PatrolDirection(PatrolDir.LEFT);
            }
            else
            {
                PatrolDirection(PatrolDir.RIGHT);
            }
        }
        else if (currentDirection == PatrolDir.LEFT)
        {
            if (travelledx < -patrolStopDistLeft)
            {
                PatrolDirection(PatrolDir.RIGHT);
            }
            else
            {
                PatrolDirection(PatrolDir.LEFT);
            }
        }
        else if (currentDirection == PatrolDir.STOPPED)
        {
            PatrolDirection(PatrolDir.STOPPED);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector2 positionLeft = (Vector2)transform.position  - (Vector2)(Vector2.right * (patrolStopDistLeft+travelledx));
        Vector2 positionRight = (Vector2)transform.position + (Vector2)(Vector2.right * (patrolStopDistRight-travelledx));

        float cubesize = 0.1f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(positionLeft, new Vector3(cubesize, cubesize*3, cubesize));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(positionRight, new Vector3(cubesize, cubesize*3, cubesize));
        
    }
}
