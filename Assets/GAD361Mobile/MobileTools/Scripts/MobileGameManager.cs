using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace Murdoch.GAD361.MobileTools
{
    public class MobileGameManager : MonoBehaviour
    {
        protected static MobileGameManager _instance;
        public RenderPipelineAsset renderPipelineAsset;
        public bool isDesktop; //this will show in inspector.
        protected bool isPaused; //is the game paused?
        public delegate void OnSceneLoaded();

        void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                Init();
            }
            
        }

        public static MobileGameManager instance
        {
            get {return _instance;}
        }

        //This will allow anyone to get 'is Desktop'
        public static bool IsDesktop
        {
            get { return _instance.isDesktop; }
        }

        public static bool Paused
        {
            get { return _instance.isPaused; }
            set { _instance.isPaused = value; }
        }

        public string CurrentScene
        {
            get { return SceneManager.GetActiveScene().name; }
        } 

        protected virtual void Init()
        {
            if (renderPipelineAsset)
            {
                GraphicsSettings.renderPipelineAsset = renderPipelineAsset;
            }
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            OnSceneChanged();
        }

        public virtual void Pause(bool pause)
        {
            isPaused = pause;
            OnPauseChanged();
        }

        public virtual void OnPauseChanged()
        {
            //override this
        }

        public virtual void OnActiveSceneChanged(Scene prev, Scene current)
        {
            OnSceneChanged();
        }

        public virtual void OnSceneChanged()
        {

        }

        public virtual void EnableTouchControls(bool shouldEnable=true)
        {
            MobileControls.controlsEnabled = shouldEnable;
        }

        public virtual void SceneTransition(string newSceneName, Animator transition = null, string triggerName = "ChangeScene", float waitTime = 0.0f)
        {
            //Without transition
            if (transition == null)
            {
                SceneManager.LoadScene(newSceneName);
            }
            else //with transition
            {
                StartCoroutine( TransitionToScene(newSceneName, transition, triggerName, waitTime ) );
            }
        }

        IEnumerator TransitionToScene(string newSceneName, Animator transition, string triggerName, float waitTime) //, OnSceneLoaded sceneLoadedFunction)
        {
            transition.SetTrigger(triggerName);
            //Debug.Log("Transitioning");
            yield return new WaitForSecondsRealtime(waitTime);
            SceneManager.LoadScene(newSceneName);
            //Don't need to do this because we subscribe.
            //OnSceneChanged();

        }
    }
}
