using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public time passed variable
    public float myTimer = 0;
    //public fxed update time
    public float myFixedTimer = 0;
    public GameObject myEnemy;
    public float spawnInterval = .5f;
    public float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add time passed between frames
        myTimer += Time.deltaTime;
        //once the interval is hit, trigger an enemy spawn and reset timer
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(myEnemy);
            Debug.Log("enemy spawn");
        }
    }

    void FixedUpdate()
    {
        //add time passed between each physics frame
        myFixedTimer+= Time.fixedDeltaTime;
    }
}
