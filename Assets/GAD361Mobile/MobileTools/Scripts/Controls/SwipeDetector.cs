using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.MobileTools
{

    public class SwipeDetector : MobileControls
    {

        public float minSwipeDistance = 25.0f; //pixels
        public bool nonSwipeIsTap = false;
        Vector2 starttouch;
        Vector2 endtouch;
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
                float v = Input.GetAxisRaw("Vertical");
                float h = Input.GetAxisRaw("Horizontal");
                Vector2 spos = Vector2.zero;
                Vector2 epos = new Vector2(h, v) * minSwipeDistance;
                //Debug.Log(epos);
                CheckSwipe(spos, epos);
            }
            else
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        starttouch = touch.position;
                        endtouch = touch.position;
                    }

                    if (touch.phase == TouchPhase.Moved) //(if !detectAfterRelease)
                    {
                        endtouch = touch.position;
                        CheckSwipe(starttouch, endtouch);
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        endtouch = touch.position;
                        if (!CheckSwipe(starttouch, endtouch) && nonSwipeIsTap)
                        {
                            //Send a tap.
                            if (OnTap != null)
                            {
                                OnTap(endtouch);
                            }
                        };
                    }
                }
            }
            
        }

        bool CheckSwipe(Vector2 s_pos, Vector2 e_pos)
        {
            float vdist = Mathf.Abs(s_pos.y - e_pos.y);
            float hdist = Mathf.Abs(s_pos.x - e_pos.x);
            bool isVerticalSwipe = (vdist > hdist);
            bool swipeDistMet = ((vdist >= minSwipeDistance) || (hdist >= minSwipeDistance));
            if (swipeDistMet)
            {
                SwipeData sdata = new SwipeData();
                if (isVerticalSwipe)
                {
                    if (e_pos.y > s_pos.y)
                    {
                        sdata.dir = Direction.Dir.UP;
                    }
                    else
                    {
                        sdata.dir = Direction.Dir.DOWN;
                    }
                }
                else
                {
                    if (e_pos.x > s_pos.x)
                    {
                        sdata.dir = Direction.Dir.RIGHT;
                    }
                    else
                    {
                        sdata.dir = Direction.Dir.LEFT;
                    }
                }
                if (OnSwipe != null)
                    OnSwipe(sdata);
                return true;
            }
            return false;
        }
    }
}