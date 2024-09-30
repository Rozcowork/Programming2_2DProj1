using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HiveMind : MonoBehaviour
{
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo();
    }

     private Vector3 MoveTo()
    {

        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, 0.001f);
        return playerPos.position;
    }
}
