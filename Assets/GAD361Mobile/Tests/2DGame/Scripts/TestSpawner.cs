using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSpawner : MonoBehaviour
{

    public GameObject[] testPrefabs;
    public GameObject parentObject;
    public int spawnAmount = 20;
    public Vector3 spawnBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float x = (Random.value * 2 * spawnBounds.x) - spawnBounds.x;
        float y = (Random.value * 2 * spawnBounds.y) - spawnBounds.y;
        float z = (Random.value * 2 * spawnBounds.z) - spawnBounds.z;
        GameObject testPrefab = testPrefabs[Random.Range(0, testPrefabs.Length)];
        GameObject g = Instantiate(testPrefab, new Vector3(x, y, z), Quaternion.identity);
        g.transform.SetParent(parentObject.transform);
    }
}
