using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Murdoch.GAD361.MobileTools;

public class Wall : MonoBehaviour
{
    public Text scoreText;
    public int scoreValue = 0;
    public GameObject WallPrefab;
    public Text FinalScoreText;
    


    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if(screenPosition.x > WallPrefab.transform.position.x )
        {
            Debug.Log("Score" + scoreValue);
            AddScore();
            
            scoreText.text = "Score" + ":" + scoreValue;
            
        }
    }
    void AddScore()
    {
scoreValue += 1;
    }
    

    
    
   
}
