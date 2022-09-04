using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;
using TMPro;

public class SwipePlatformerManager : MobileGameManager
{
    int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    public GameObject menuUI;
    public GameObject gameUI;
    public string gameSceneName;
    public string menuSceneName;

    // Start is called before the first frame update
    void Start()
    {
        OnSceneChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        SceneTransition(gameSceneName);
    }

    public void BackToMenu()
    {
        SceneTransition(menuSceneName);
    }

    public void AddScore(int morescore)
    {
        score += morescore;
        //Debug.Log(score);
        scoreText.text = "Score: " + score;
    }

    public override void OnSceneChanged()
    {
        if (CurrentScene == gameSceneName)
        {
            score = 0;
            AddScore(0);
            gameUI.SetActive(true);
            gameOverUI.SetActive(false);
            menuUI.SetActive(false);
            EnableTouchControls(true);
            Pause(false);
        }
        else if (CurrentScene == menuSceneName)
        {
            gameUI.SetActive(false);
            gameOverUI.SetActive(false);
            menuUI.SetActive(true);
            EnableTouchControls(false);
            Pause(false);
        }
    }
}
