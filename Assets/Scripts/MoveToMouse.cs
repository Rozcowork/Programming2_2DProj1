using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    //accel is public so we can fine tune the player controller from the editor
    //separate horizontal and vertical accelerations
    public float speed = 5f;
    private Vector3 target;
    public GameManager myManager;
    public SceneChanger MySceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("click to move");
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
       transform.position = Vector3.MoveTowards(transform.position, target, speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            MySceneChanger.MoveToScene(2);
        }
    }
}
