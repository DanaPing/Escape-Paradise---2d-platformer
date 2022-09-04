using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;
using TMPro;

public class Inf2DSideManager : MobileGameManager
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    public TextMeshProUGUI gameOverUIScoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText(float score)
    {
        scoreText.text = "" + (int)score;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameOverUIScoreText.text = "Your score was: " + scoreText.text;
        Time.timeScale = 0.0f; //stop everything
    }

    public void PlayAgain()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1.0f; //start time again
        SceneTransition("InfSidescroll");
    }
}
