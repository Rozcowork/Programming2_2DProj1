using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkRay : MonoBehaviour
{
    Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(shrink(.1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator shrink(float time)
    {
        while (true)
        {
            //code that slightly shrinks the ray goes here
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*.95f, transform.localScale.z);
            yield return new WaitForSeconds(time);

        }
    }

    public void resetScale()
    {
        transform.localScale = originalScale;

    }
}
