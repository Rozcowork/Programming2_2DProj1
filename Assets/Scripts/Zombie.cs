using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject objectPrefab;

    public float xBound;
    public float yBound;
    public float spawnTimer;
    public float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTimer)
        {
            spawnTimer = 0f;
            //Instantiate(objectPrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    
   
}
