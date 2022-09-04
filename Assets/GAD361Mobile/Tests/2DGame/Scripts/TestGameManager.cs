using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;
using UnityEngine.UI;

public class TestGameManager : MobileGameManager
{
    public string gameSceneName;
    public string menuSceneName;
    public GameObject mainMenuObject;
    public GameObject pauseMenuObject;
    public GameObject pauseButton;
    public Animator sceneTransitionAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDesktop)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && CurrentScene == gameSceneName)
            {
                Pause(true);
            }
        }
    }

    public void RunGameScene()
    {
        SceneTransition(gameSceneName, sceneTransitionAnimator, "ChangeScene", 1.0f); //, StartGameScene);
    }

    public void RunMenuScene()
    {
        SceneTransition(menuSceneName, sceneTransitionAnimator, "ChangeScene", 1.0f);//, StartMenuScene);
    }

    public override void OnPauseChanged()
    {
        pauseMenuObject.SetActive(isPaused);
    }

    public override void OnSceneChanged()
    {
        if (CurrentScene == gameSceneName)
        {
            Debug.Log("GAME SCENE");
            mainMenuObject.SetActive(false);
            pauseButton.SetActive(true);
            EnableTouchControls(true);
            Pause(false); //unpause if paused
        }
        else if (CurrentScene == menuSceneName)
        {
            Debug.Log("MENU SCENE");
            mainMenuObject.SetActive(true);
            pauseButton.SetActive(false);
            EnableTouchControls(false);
            Pause(false);
        }
    }
}
