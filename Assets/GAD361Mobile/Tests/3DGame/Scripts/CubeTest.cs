using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    Vector3 rotSpeeds;
    // Start is called before the first frame update
    void Start()
    {
        float xrot = Random.value * 180;
        float yrot = Random.value * 180;
        float zrot = Random.value * 180;
        rotSpeeds = new Vector3(xrot, yrot, zrot);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotSpeeds * Time.deltaTime);
    }
}
