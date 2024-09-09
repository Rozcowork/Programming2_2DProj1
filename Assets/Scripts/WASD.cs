using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float collectedScore = 0f;
    //accel is public so we can fine tune the player controller from the editor
    //separate horizontal and vertical accelerations
    public float horAccel = .1f;
    public float vertAccel = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fixed Update is called every physics update
    //It is a void function, so it does not return any data
    void FixedUpdate()
    {
        //First let's call our Dir() function to find out what the current player inputs are
        Vector3 currentDir = Dir();
        currentDir.x *= horAccel;
        currentDir.y *= vertAccel;
        //throw it into Translate, multiply by our acceleration variable
        transform.Translate(currentDir);
    }

    //Get the inputs of the WASD / Keyboard / joysticks
    //This function gets the overall direction and returns it as a vector3
    public Vector3 Dir()
    {
        //Unity's default Axis provide a value between  -1 to 1
        //in the case of Vertical, that's W = 1 and S = -1
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        
        //construct our vector out of the vertical/horizontal axis
        Vector3 myDir = new Vector3(x, y, 0);
        //Then we return that value
        return myDir;
    }
    //checking for enemy or collectible collisions
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player collided with " + collision.gameObject.name);

        //when we collide with something collectible, destroy it and increment the player score
        if(collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            collectedScore++;
        }
    }
}
