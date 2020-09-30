using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraMovement : MonoBehaviour
{
    float xNeeded = 4;
    float yNeeded = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > xNeeded + 3 && transform.position.x < 18.5)
        {
            transform.position = transform.position + new Vector3(.05f, 0, 0);
            xNeeded = xNeeded + .05f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > xNeeded && transform.position.x < 18.5)
        {
            transform.position = transform.position + new Vector3(.03f, 0, 0);
            xNeeded = xNeeded + .03f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xNeeded - 13 && transform.position.x > -18.5)
        {
            transform.position = transform.position + new Vector3(-.05f, 0, 0);
            xNeeded = xNeeded - .05f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xNeeded - 10 && transform.position.x > -18.5)
        {
            transform.position = transform.position + new Vector3(-.03f, 0, 0);
            xNeeded = xNeeded - .03f;
        }

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yNeeded + 1.5f && transform.position.y < 20)
        {
            transform.position = transform.position + new Vector3(0, .05f, 0);
            yNeeded = yNeeded + .05f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yNeeded && transform.position.y < 20)
        {
            transform.position = transform.position + new Vector3(0, .03f, 0);
            yNeeded = yNeeded + .03f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yNeeded - 7.5 && transform.position.y > -20)
        {
            transform.position = transform.position + new Vector3(0, -.05f, 0);
            yNeeded = yNeeded - .05f;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yNeeded - 6 && transform.position.y > -20)
        {
            transform.position = transform.position + new Vector3(0, -.03f, 0);
            yNeeded = yNeeded - .03f;
        }
        */
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > xNeeded && transform.position.x < 18.5)
        {
            transform.position = transform.position + new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - xNeeded) / 100, 0, 0);
            xNeeded = xNeeded + ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - xNeeded) / 100);
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < xNeeded - 8 && transform.position.x > -18.5)
        {
            transform.position = transform.position + new Vector3(-((xNeeded - 8 - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) / 100), 0, 0);
            xNeeded = xNeeded - (xNeeded - 8 - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) / 100;
        }

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > yNeeded && transform.position.y < 20)
        {
            transform.position = transform.position + new Vector3(0, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - yNeeded) / 80, 0);
            yNeeded = yNeeded + ((Camera.main.ScreenToWorldPoint(Input.mousePosition).y - yNeeded) / 90);
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < yNeeded - 6 && transform.position.y > -20)
        {
            transform.position = transform.position + new Vector3(0, -((yNeeded - 6 - Camera.main.ScreenToWorldPoint(Input.mousePosition).y) / 80), 0);
            yNeeded = yNeeded - (yNeeded - 6 - Camera.main.ScreenToWorldPoint(Input.mousePosition).y) / 80;
        }
    }
}
