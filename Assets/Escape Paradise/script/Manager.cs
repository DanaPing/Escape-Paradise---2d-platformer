using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(1);
    }
   
}
