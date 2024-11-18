using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //call the projectile prefab
    public Transform launchPoint; //call the position of the Launch Point

    //COOLDOWNTIMER STUFF
    public float shootTime = 2f; //how long the time is before you can launch the projectile
    public float shootCount; //the timer on the shot

    public enum stateMode
    {
        RED,
        GRAY,
        BLUE,
    }
    public stateMode myMode;
    Renderer myRend;
    Material myMat;
    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<Renderer>();
        myMat = myRend.material;
        shootCount = shootTime; //at the beginning the you have to wait 0.5s before shooting
        InvokeRepeating("Explode", shootTime, shootCount);
    }

    // Update is called once per frame
    void Update()
    {
        switch (myMode)
        {
            case stateMode.RED:
                myMat.color = Color.red;
                break;

            case stateMode.BLUE:
                myMat.color = Color.blue;
                break;

            case stateMode.GRAY:
                myMat.color = Color.gray;
                break;

        }
    }

    private void Explode()
    {
        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
    }
}
