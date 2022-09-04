using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.MobileTools
{

    public class MultiTouch : MobileControls
    {
        //public bool zeroZPositions = true;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (!controlsEnabled)
                return;

            //multitouch
            /*
            if (Input.touchCount > 0)
            {
                
                Vector3[] touches = new Vector3[Input.touchCount]; 
                //Find the position in the scene of each touch
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Vector3 touchposition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                    //For 2D games we zero the z positions
                    if (zeroZPositions == true)
                    { 
                        touchposition.z = 0.0f;
                    }
                    touches[i] = touchposition;
                }

                MobileControls.OnTouch(touches);
                
            }
            */
            MobileControls.OnTouch(Input.touches);
        }
    }
}
