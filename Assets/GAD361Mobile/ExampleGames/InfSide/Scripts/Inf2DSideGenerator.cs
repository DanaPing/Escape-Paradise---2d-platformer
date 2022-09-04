using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inf2DSideGenerator : MonoBehaviour
{
    public GameObject prefab;
    Inf2DSideScroll scroller;
    public float minDistBetween = 1.0f;
    public float maxDistBetween = 2.0f;
    public float yMin = 0;
    public float yMax = 0;

    float nextGenerateDistance;
    float lastGenerateDistance;
    float distSinceLastGenerate;
    Vector2 generationPoint;

    // Start is called before the first frame update
    void Start()
    {
        scroller = GetComponent<Inf2DSideScroll>();
        distSinceLastGenerate = 0;
        lastGenerateDistance = 0;
        nextGenerateDistance = GetNextGenerateDist();
        Debug.Log("Screen width: " + Screen.width);
        generationPoint = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.transform.position.z));
        Debug.Log("gen point" + generationPoint);
    }

    // Update is called once per frame
    void Update()
    {
        distSinceLastGenerate = scroller.DistanceScrolled() - lastGenerateDistance;
        if (distSinceLastGenerate > nextGenerateDistance)
        {
            Generate();
            distSinceLastGenerate = 0;
            lastGenerateDistance = nextGenerateDistance;
            nextGenerateDistance = lastGenerateDistance + GetNextGenerateDist();
        }
    }

    float GetNextGenerateDist()
    {
        float r = Random.Range(minDistBetween, maxDistBetween);
        return r;
    }

    void Generate()
    {
        float ry = Random.Range(yMin, yMax);
        //gen point is Screen.Width
        // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 5));
        //groundBase.transform.position = worldPoint;
        GameObject g = Instantiate(prefab, new Vector2(generationPoint.x, ry), Quaternion.identity);
        g.transform.SetParent(transform);
    }
}
