using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D projectileRb; //Rigidbody of the projectile
    public float speed = 3; //Speed of the projectile

    //PROJECTILE COUNTDOWN TIMER
    public float projectileLife = 2;//Lifetime of the projectile
    public float projectileCount;//Timer for the projectile

    public WASD playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        projectileCount = projectileLife; //timer for the projectile to equal the lifetime of the projectile
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime; //reduce the liftime of the projectile

        if (projectileCount <= 0) // when the projectile count equals zero destroy the object
        {
            Destroy(gameObject); // when the projectile lifetime reaches 0 destroy the projectile
        }
    }

    void FixedUpdate()
    {
        projectileRb.AddForce(Vector3.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) // when the projectile collides with object
    {
        if (collision.gameObject.tag == "Zombie") //if projectile is colliding with the Enemy
        {
            Destroy(collision.gameObject); //When projectile hits the Enemy the Enemy will be destroyed
        }

        Destroy(gameObject); //when the projectile collides with the anything the projectile will destroy itself
    }
}
