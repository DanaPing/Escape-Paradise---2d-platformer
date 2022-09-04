using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Murdoch.GAD361.MobileTools
{
    public class SwipeData
    {
        public Direction.Dir dir;
        public Vector2 pos;
        //could also have extra data here for 
        //- length/velocity of swipe
        //- position on screen where swipe occurred
    }

    public class MobileControls : MonoBehaviour
    {
        //public delegate void OnTap(Action<Vector2> pos);
        //static public event Action<Vector2> OnTap = delegate{};
        public delegate void PosDelegate(Vector2 pos);
        public delegate void SwipeDelegate(SwipeData swipe);
        public delegate void TouchArrayDelegate(Touch[] touches);
        public static PosDelegate OnTap;
        public static PosDelegate OnTilt; //'pos' is just a vector2
        public static SwipeDelegate OnSwipe;
        public static TouchArrayDelegate OnTouch;
        public static bool controlsEnabled = true;
        //public bool isDesktop = false;

    }
}
