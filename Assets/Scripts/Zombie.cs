using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Zombie : MonoBehaviour
{
    //Calling the Zombie Prefab
    public GameObject objectPrefab;
    //Areas for Spawning Zombies
    public float xBound;
    public float yBound;
    public float xBound1;
    public float yBound1;
    public float xBound2;
    public float yBound2;
    public float xBound3;
    public float yBound3;
    //
    public float spawnTimer;
    public float spawnInterval = 1f;
    public Transform playerPos;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Vector3 spawn = Spawn();
            Debug.Log(spawn);
            Instantiate(objectPrefab, spawn, Quaternion.identity);
        }
        
    }

    private Vector3 Spawn()
    {
        int random = (int)Mathf.Round(Random.Range(0, 4));
        if (random == 0)
        {
            return SpawnRight();
        } 

        else if (random == 1) 
        {
            return SpawnLeft();
        }

        else if (random == 2) 
        {
            return SpawnTop();
        }

        else
        {
            return SpawnBottom();
        }
    }
    private Vector3 SpawnRight()
    {
        float x = Random.Range(xBound1 + playerPos.position.x, xBound + playerPos.position.x);
        float y = Random.Range(yBound3 + playerPos.position.y, yBound + playerPos.position.y);
        return new Vector3(x, y, 0);
       
    }
    
    private Vector3 SpawnLeft()
    {
        float x = Random.Range(xBound2 + playerPos.position.x, xBound3 + playerPos.position.x);
        float y = Random.Range(yBound3 + playerPos.position.y, yBound + playerPos.position.y);
        return new Vector3(x, y, 0);
    }

    private Vector3 SpawnTop()
    {
        float x = Random.Range(xBound2 + playerPos.position.x, xBound + playerPos.position.x);
        float y = Random.Range(yBound1 + playerPos.position.y, yBound + playerPos.position.y);
        return new Vector3(x, y, 0);
    }

    private Vector3 SpawnBottom()
    {
        float x = Random.Range(xBound2 + playerPos.position.x, xBound + playerPos.position.x);
        float y = Random.Range(yBound3 + playerPos.position.y, yBound2 + playerPos.position.y);
        return new Vector3(x, y, 0);
    }
}
