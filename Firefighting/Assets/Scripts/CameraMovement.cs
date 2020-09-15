using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraMovement : MonoBehaviour
{
    float xNeeded = 5;
    float yNeeded = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > xNeeded + 3 && transform.position.x < 18.5)
        {
            transform.position = transform.position + new Vector3(.03f, 0, 0);
            xNeeded = xNeeded + .03f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > xNeeded && transform.position.x < 18.5)
        {
            transform.position = transform.position + new Vector3(.01f, 0, 0);
            xNeeded = xNeeded + .01f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xNeeded - 13 && transform.position.x > -18.5)
        {
            transform.position = transform.position + new Vector3(-.03f, 0, 0);
            xNeeded = xNeeded - .03f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xNeeded - 10 && transform.position.x > -18.5)
        {
            transform.position = transform.position + new Vector3(-.01f, 0, 0);
            xNeeded = xNeeded - .01f;
        }

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yNeeded + 1.5f && transform.position.y < 20)
        {
            transform.position = transform.position + new Vector3(0, .03f, 0);
            yNeeded = yNeeded + .03f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yNeeded && transform.position.y < 20)
        {
            transform.position = transform.position + new Vector3(0, .01f, 0);
            yNeeded = yNeeded + .01f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yNeeded - 7.5 && transform.position.y > -20)
        {
            transform.position = transform.position + new Vector3(0, -.03f, 0);
            yNeeded = yNeeded - .03f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yNeeded - 6 && transform.position.y > -20)
        {
            transform.position = transform.position + new Vector3(0, -.01f, 0);
            yNeeded = yNeeded - .01f;
        }
    }
}
