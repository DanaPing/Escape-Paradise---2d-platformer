using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject ball;
    public GameObject go;
    Scroll scroll;
    public float xMin = 1.0f;
    public float xmax = 1.0f;
    public float  yMin = 0;
    public float ymax = 0;

    float nextGenerate;
    float lastGenerate;
    float distBetweenlast;
    Vector2 generationPoint;
    // Start is called before the first frame update
    void Start()
    {
        scroll = GetComponent<Scroll>();
        distBetweenlast = 0;
        lastGenerate = 0;
        nextGenerate = GetNextGenerateDist();
        Debug.Log("Screen" + Screen.width);
        generationPoint = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.transform.position.z));
        Debug.Log("generate" + generationPoint);

    }

    // Update is called once per frame
    void Update()
    { 
       

      

       
        distBetweenlast = scroll.DistanceScrolled() - lastGenerate;
        if(distBetweenlast > nextGenerate)
        {
            Generate();
            distBetweenlast = 0;
            lastGenerate = nextGenerate;
            nextGenerate = lastGenerate + GetNextGenerateDist();
        }
         
         
        
    }
    float GetNextGenerateDist()
    {
        float r = Random.Range(xMin, xmax);
        return r;
    
    }
    void Generate()
    {
        float ry = Random.Range(yMin, ymax);
        GameObject g =Instantiate(go, new Vector2(generationPoint.x, ry), Quaternion.identity);
        g.transform.SetParent(transform);
    }
}
