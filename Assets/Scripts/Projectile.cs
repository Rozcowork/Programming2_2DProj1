using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D projectileRb; //Rigidbody of the projectile
    public float speed = 4; //Speed of the projectile

    //PROJECTILE COUNTDOWN TIMER
    public float projectileLife = 5;//Lifetime of the projectile
    public float projectileCount;//Timer for the projectile

    public MoveToMouse playerControllerScript;
    public GameManager myManager;

   

    // Start is called before the first frame update
    void Start()
    {
        
        projectileRb = GetComponent<Rigidbody2D>();
        projectileCount = projectileLife; //timer for the projectile to equal the lifetime of the projectile
        myManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        Vector3 targetDir = transform.up;
        //Debug.DrawRay(transform.position, targetDir, Color.cyan);
        projectileRb.AddForce(targetDir * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) // when the projectile collides with object
    {
        if (collision.gameObject.tag == "Zombie") //if projectile is colliding with the Enemy
        {
            Destroy(collision.gameObject); //When projectile hits the Enemy the Enemy will be destroyed
            myManager.ZombieDead();
        }

        Destroy(gameObject); //when the projectile collides with the anything the projectile will destroy itself
    }
}
