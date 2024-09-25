using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float collectedScore = 0f;
    //accel is public so we can fine tune the player controller from the editor
    //separate horizontal and vertical accelerations
    public float horAccel = 1f;
    public float vertAccel = 1f;

    //"Flip" direction variables
    public bool flippedLeft; //keep track of which way our sprite is Currently facing
    public bool facingLeft; //keeps track of which way our sprite Should be facing

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
        Vector3 newPos = transform.position;
        if (currentDir.x > 0)
        {
            newPos.x += horAccel; //when "A" is pressed go left 
            facingLeft = false; //set the boolean to false when facing right
            Flip(facingLeft); //call the Flip Facing left void
        }
        else if (currentDir.x < 0)
        {
            newPos.x -= horAccel;//when "D" is pressed go right
            facingLeft = true; //set the boolean to true when facing left
            Flip(facingLeft); //call the Flip Facing left void
        }
        if (currentDir.y > 0)
        {
            newPos.y += vertAccel;//when "W" is pressed go up
        }
        else if (currentDir.y < 0)
        {
            newPos.y -= vertAccel;//when "S" is pressed go down
        }
        currentDir.x *= horAccel;
        currentDir.y *= vertAccel;
        //throw it into Translate, multiply by our acceleration variable
        transform.Translate(currentDir);
        transform.position = newPos;//close the loop of the if statements to move player
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
    void Flip(bool facingLeft) //this void flips the character
    {
        //Debug.Log("Flip() called. facingRight = " + facingRight);
        if (facingLeft && !flippedLeft) //if facingLeft is true and the flippedLeft is false rotate the player
        {
            transform.Rotate(0, -180, 0); //change the way the player is facing to the left 
            flippedLeft = true; //set the boolean to true
        }

        if (flippedLeft && !facingLeft) //if flipped Left is true and the facingLeft is false rotate the player
        {
            transform.Rotate(0, 180, 0); //change the way the player is facing to the right
            flippedLeft = false; //set the booolean to false
        }
    }
}
