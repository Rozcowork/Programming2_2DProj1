using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
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

       // if(myMode!= prevMode)
    }

    void EnterRed()
    {
        myMat.color = Color.red;
        InvokeRepeating("Explode", shootTime, shootCount);
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
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);
            if (d <= 7)
            {
                Explode();
            }
            foreach (Zombie z in FindObjectsOfType<Zombie>()) { GameObject o = z.gameObject; }

        }
    }
}
