using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //call the projectile prefab
    public Transform launchPoint; //call the position of the Launch Point

    //COOLDOWNTIMER STUFF
    public float shootTime = 0.5f; //how long the time is before you can launch the projectile
    public float shootCount; //the timer on the shot

    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime; //at the beginning the you have to wait 0.5s before shooting
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shootCount <= 0) //if you press the Left Mouse Button Down and you have not shot, you can shoot
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity); //to launch the prefab at the position of the LaunchPoint

            shootCount = shootTime; //Make the shot count the same as the shooting time
        }

        shootCount -= Time.deltaTime; //reduce the shoot count timer
    }
}
