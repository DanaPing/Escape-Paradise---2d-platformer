using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Murdoch.GAD361.MobileTools
{
    public class DebugPanel : MonoBehaviour
    {
        public Text fpsText;
        private int fps;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (fpsText != null)
            {
                fps = (int)(1f / Time.unscaledDeltaTime);
                fpsText.text = "FPS: " + fps;
            }
        }

        void Debug(string name, string value)
        {

        }
    }
}