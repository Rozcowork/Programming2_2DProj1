using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileLaunch : MonoBehaviour
{
    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //call the projectile prefab
    public GameObject projectilePrefab1;
    public Transform launchPoint; //call the position of the Launch Point
    public Transform launchPoint1;
    public Transform launchPoint2;
    public Transform launchPoint3;
    public Transform launchPoint4;
    public Transform launchPoint5;
    public Transform launchPoint6;
    public Transform launchPoint7;
    //COOLDOWNTIMER STUFF
    public float shootTime = 10f; //how long the time is before you can launch the projectile
    public float shootCount; //the timer on the shot

    public enum stateMode
    {
        RED,
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
        InvokeRepeating("Shoot", shootTime, shootCount);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        {
            
        }
        switch (myMode)
        {
            case stateMode.RED:
                myMat.color = Color.red;
                break;

            case stateMode.BLUE:
                myMat.color = Color.blue;
                break;

        }

       // if(myMode!= prevMode)
    }
    void Shoot()
    {
        if (myMode == stateMode.RED)
        {
            Explode();
        }
        else if (myMode == stateMode.BLUE)
        {
            Laser();
        }

    }

    void EnterRed()
    {
        myMat.color = Color.red;
    }

    void EnterBlue()
    {
        myMat.color = Color.blue;
    }
    
    void EnterGray()
    {
        myMat.color = Color.gray;
    }

    private void Explode()
    {
        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint1.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint2.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint3.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint4.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint5.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint6.position, Quaternion.identity);
        Instantiate(projectilePrefab, launchPoint7.position, Quaternion.identity);

    }
    private void Laser()
    {
        Instantiate(projectilePrefab1, launchPoint1.position, Quaternion.identity);
        Instantiate(projectilePrefab1, launchPoint3.position, Quaternion.identity);
        Instantiate(projectilePrefab1, launchPoint5.position, Quaternion.identity);
        Instantiate(projectilePrefab1, launchPoint7.position, Quaternion.identity);
    }
}
