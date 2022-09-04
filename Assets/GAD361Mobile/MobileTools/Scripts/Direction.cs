using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.MobileTools
{

    public class Direction
    {
        public enum Dir
        {
        UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public static Vector2 DirToVec2(Dir dir)
        {
            Vector2 retval = Vector2.right;
            switch (dir)
            {
                case Direction.Dir.UP:
                    retval = Vector2.up;
                    break;
                case Direction.Dir.DOWN:
                    retval = Vector2.down;
                    break;
                case Direction.Dir.RIGHT:
                    retval = Vector2.right;
                    break;
                case Direction.Dir.LEFT:
                    retval = Vector2.left;
                    break;
            }
            return retval;
        }
    }
}