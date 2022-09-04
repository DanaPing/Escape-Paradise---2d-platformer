using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;

public class SwipeControls : MonoBehaviour
{
    void Awake()
    {
        if (TestGameManager.instance.isDesktop)
        {
            //MobileControls.Instance.isDesktop = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MobileControls.OnSwipe += OnSwipe;
        MobileControls.OnTap += OnTap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwipe(SwipeData swipe)
    {
        if (swipe.dir == Direction.Dir.LEFT)
        {
            transform.position += (Vector3)Vector2.left;
        }
        else if (swipe.dir == Direction.Dir.RIGHT)
        {
            transform.position += (Vector3)Vector2.right;
        }
    }

    public void OnTap(Vector2 tappos)
    {
        Debug.Log("Tapped " + tappos);
    }

    void OnDestroy()
    {
        MobileControls.OnSwipe -= OnSwipe;
        MobileControls.OnTap -= OnTap;
    }
}
