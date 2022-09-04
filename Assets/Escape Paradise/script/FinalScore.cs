using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public Text FinalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Final score");
         Wall wall = GameObject.Find("Score").GetComponent<Wall>();
       FinalScoreText.text = "Score" + ":" +  wall.scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    
    
}
