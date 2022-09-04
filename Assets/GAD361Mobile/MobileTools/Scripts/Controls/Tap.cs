using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.MobileTools
{

    public class Tap : MobileControls
    {
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (!controlsEnabled)
                return;
            //if (isDesktop)
            if (MobileGameManager.IsDesktop)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (OnTap != null)
                        OnTap(Input.mousePosition);
                }
            }
            else
            {
                //1. Do this first touch
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
                        touchposition.z = 0.0f;
                        if (OnTap != null)
                            OnTap((Vector2)touchposition);
                    }
                }
            }
        }
    }
}