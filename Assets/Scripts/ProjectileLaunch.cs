using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileLaunch : MonoBehaviour
{
    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //call the projectile prefab
    public GameObject projectilePrefab1;

    //All the Launch Points
    public Transform launchPoint;
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

    private Vector3 target;
    public GameObject aimer;
    public enum stateMode
    {
        RED,
        BLUE,
    }
    public stateMode myMode;
    Renderer myRend;
    Material myMat;
    public GameObject laser;
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
        aimer.transform.position = AimerPos();
        if (Input.GetMouseButtonDown(1))
        {
            if (myMode== stateMode.RED)
            {
                myMode = stateMode.BLUE; 
                myMat.color = Color.blue; 
                Laser();
            }
            else if (myMode== stateMode.BLUE)
            {
                myMode = stateMode.RED;
                myMat.color = Color.red;
            }
        }
        if (myMode== stateMode.BLUE)
        {
            laserpath();
        }
    }
    void Shoot()
    {
        if (myMode == stateMode.RED)
        {
            Explode();
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
    private void Explode()
    {
        Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        Instantiate(projectilePrefab, launchPoint1.position, launchPoint1.rotation);
        Instantiate(projectilePrefab, launchPoint2.position, launchPoint2.rotation);
        Instantiate(projectilePrefab, launchPoint3.position, launchPoint3.rotation);
        Instantiate(projectilePrefab, launchPoint4.position, launchPoint4.rotation);
        Instantiate(projectilePrefab, launchPoint5.position, launchPoint5.rotation);
        Instantiate(projectilePrefab, launchPoint6.position, launchPoint6.rotation);
        Instantiate(projectilePrefab, launchPoint7.position, launchPoint7.rotation);
    }
    private void Laser()
    {

        laser.SetActive(true);
        laserpath();
        //Instantiate(projectilePrefab1, launchPoint1.position, launchPoint1.rotation);
        //Instantiate(projectilePrefab1, launchPoint3.position, launchPoint3.rotation);
        //Instantiate(projectilePrefab1, launchPoint5.position, launchPoint5.rotation);
        //Instantiate(projectilePrefab1, launchPoint7.position, launchPoint7.rotation);
    }
    private void laserpath()
    {
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //target.z = transform.position.z;
        //Vector3 playerpos = transform.position;
        //Vector3 direction = target - playerpos;
       // Quaternion quaternion= Quaternion.RotateTowards()
       // Debug.Log(quaternion);
        //transform.rotation.localEulerAngles = new Vector3(floatx,floaty,floatz);

    }

    Vector3 AimerPos()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mouse;
    }
}
