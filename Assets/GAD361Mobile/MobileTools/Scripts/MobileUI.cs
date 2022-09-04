using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Murdoch.GAD361.MobileTools
{
    public class MobileUI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //Turn the object on or off based on a value.
        public virtual void Show(bool show)
        {
            gameObject.SetActive(show);
            MobileGameManager.instance.EnableTouchControls(!show);
        }
    }
}