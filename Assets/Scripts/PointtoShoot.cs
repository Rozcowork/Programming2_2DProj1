using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointtoShoot : MonoBehaviour
{

    public GameManager myManager;
    // Start is called before the first frame update
    void Start()
    {
        myManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) // when the projectile collides with object
    {
        if (collision.gameObject.tag == "Zombie") //if projectile is colliding with the Enemy
        {
            Destroy(collision.gameObject); //When projectile hits the Enemy the Enemy will be destroyed
            myManager.ZombieDead();
        }

       
    }
}
