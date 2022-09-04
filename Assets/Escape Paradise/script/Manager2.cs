using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murdoch.GAD361.MobileTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager2 : MobileGameManager
{
    public Text scoreText;
    public Text Finalscore;
    public GameObject gameoverscreen;
   //public GameObject gameplayscreen;
    
    // Start is called before the first frame update
    void Start()
    {
      gameoverscreen.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        
        gameoverscreen.SetActive(true);
        Finalscore.text = scoreText.text;
       // gameplayscreen.SetActive(false);
        
    }
    public void GamePlay()
    {
        gameoverscreen.SetActive(false);
        Debug.Log("restart");
       SceneTransition("GamePlay");
//gameplayscreen.SetActive(true);
    }
    public void gameover()
    {
        SceneTransition("Monetisation");
    }
    
}
