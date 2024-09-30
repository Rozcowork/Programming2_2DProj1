using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public time passed variable
    public float myTimer = 0;
    //public fxed update time
    public float myFixedTimer = 0;
    //explicit references to the enemy, player, and score
    public GameObject myZombie;
    public GameObject myPlayer;
    public TextMeshProUGUI playerScoreText;
    WASD playerScript;
    public int playerScore = 0;

    public float spawnInterval = .5f;
    public float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        playerScript = myPlayer.GetComponent<WASD>();
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
            Instantiate(myZombie);
            Debug.Log("enemy spawn");
        }
        playerScoreText.text = "Score: " + playerScore;
    }

    public void ZombieDead() // Update score
    {
        playerScore++; //Increase player score to add one to previous number in short hand
    }

    void FixedUpdate()
    {
        //add time passed between each physics frame
        myFixedTimer+= Time.fixedDeltaTime;
    }
}
