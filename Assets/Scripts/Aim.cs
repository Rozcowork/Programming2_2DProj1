using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject laser;

    public GameManager myManager;
    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(laser.transform.localScale.y < 0)
        {
            laser.SetActive(false);
        }
        else
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) // when the projectile collides with object
    {
        if (collider.gameObject.tag == "Zombie") //if projectile is colliding with the Enemy
        {
            Destroy(collider.gameObject); //When projectile hits the Enemy the Enemy will be destroyed
            myManager.ZombieDead();
        }
    }
}
