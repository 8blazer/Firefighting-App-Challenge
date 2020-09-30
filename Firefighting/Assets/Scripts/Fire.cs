using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float x = -24.5f;
    float y = 24.5f;
    int i = 0;
    int position;
    float spreadTimer;
    float dieTimer;
    float detectionTimer;
    bool detectionTimerGoing = false;
    public GameObject firePrefab;
    public GameObject detectorPrefab;
    public GameObject ashPrefab;
    GameObject mapGenerator;
    GameObject windController;
    GameObject upDetector;
    GameObject rightDetector;
    GameObject downDetector;
    GameObject leftDetector;
    string detectionDirection = "up";
    public bool detected = false;
    bool reset = true;
    int windFactor;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = GameObject.Find("MapGenerator");
        windController = GameObject.Find("WindController");
        if (transform.childCount > 0)
        {
            while (transform.childCount > 0 && i < 5)
            {
                Destroy(transform.GetChild(1).gameObject);
                i++;
            }
        }
        upDetector = Instantiate(detectorPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        rightDetector = Instantiate(detectorPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        downDetector = Instantiate(detectorPrefab, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
        leftDetector = Instantiate(detectorPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
        upDetector.transform.parent = gameObject.transform;
        rightDetector.transform.parent = gameObject.transform;
        downDetector.transform.parent = gameObject.transform;
        leftDetector.transform.parent = gameObject.transform;
        upDetector.GetComponent<WaterDetector>().enabled = false;
        leftDetector.GetComponent<WaterDetector>().enabled = false;
        downDetector.GetComponent<WaterDetector>().enabled = false;
        rightDetector.GetComponent<WaterDetector>().enabled = false;
        while (x != transform.position.x || y != transform.position.y) //Find where this fire is
        {
            if (x == 24.5)
            {
                x = -24.5f;
                y--;
            }
            else
            {
                x++;
            }
            i++;
        }
        position = i;
    }

    // Update is called once per frame
    void Update()
    {
        bool upFire = false;
        bool rightFire = false;
        bool downFire = false;
        bool leftFire = false;

        if (x == 24.5)
        {
            rightFire = true;
        }
        else if (x == -24.5)
        {
            leftFire = true;
        }
        if (y == 24.5)
        {
            upFire = true;
        }
        else if (y == -24.5)
        {
            downFire = true;
        }

        if ((rightFire == true || mapGenerator.GetComponent<MapGenerator>().tiles[i + 1] > 49) && (downFire == true || mapGenerator.GetComponent<MapGenerator>().tiles[i + 50] > 49) && (leftFire == true || mapGenerator.GetComponent<MapGenerator>().tiles[i - 1] > 49) && (upFire == true || mapGenerator.GetComponent<MapGenerator>().tiles[i - 50] > 49))
        {
            spreadTimer = 0;
        }

        spreadTimer += Time.deltaTime;
        dieTimer += Time.deltaTime;
        if (detectionTimerGoing)
        {
            detectionTimer += Time.deltaTime;
        }
        else
        {
            detectionTimer = 0;
        }
        if (spreadTimer > 5)
        {
            if (detectionDirection == "up")
            {
                i = i - 50; //Move up to check if it should light
                y++;
                upDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                rightDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                downDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                leftDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                if (windController.GetComponent<Wind>().windDirection < 3 || windController.GetComponent<Wind>().windDirection == 8)
                {
                    windFactor = -1;
                }
                else if (windController.GetComponent<Wind>().windDirection > 3 && windController.GetComponent<Wind>().windDirection < 7)
                {
                    windFactor = 3;
                }
                else
                {
                    windFactor = 0;
                }
                reset = false;
                if (y == 25.5)
                {
                    reset = true;
                    detectionDirection = "right";
                    i = i + 50;
                    y--;
                    upDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                    rightDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                    downDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                    leftDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                }
            }
            if (detectionDirection == "right")
            {
                i++; //Move right to check if it should light
                x++;
                upDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                rightDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                downDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                leftDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                if (windController.GetComponent<Wind>().windDirection > 1 && windController.GetComponent<Wind>().windDirection < 5)
                {
                    windFactor = -1;
                }
                else if (windController.GetComponent<Wind>().windDirection > 5)
                {
                    windFactor = 3;
                }
                else
                {
                    windFactor = 0;
                }
                reset = false;
                if (x == 25.5)
                {
                    reset = true;
                    detectionDirection = "down";
                    i--;
                    x--;
                    upDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                    rightDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                    downDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                    leftDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                }
            }
            if (detectionDirection == "down")
            {
                i = i + 50; //Move down to check if it should light
                y--;
                upDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                rightDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                downDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                leftDetector.transform.position = upDetector.transform.position + new Vector3(0, -1, 0);
                if (windController.GetComponent<Wind>().windDirection < 7 || windController.GetComponent<Wind>().windDirection > 3)
                {
                    windFactor = -1;
                }
                else if (windController.GetComponent<Wind>().windDirection < 3 || windController.GetComponent<Wind>().windDirection == 8)
                {
                    windFactor = 3;
                }
                else
                {
                    windFactor = 0;
                }
                reset = false;
                if (y == -25.5)
                {
                    reset = true;
                    detectionDirection = "left";
                    i = i - 50;
                    y++;
                    upDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                    rightDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                    downDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                    leftDetector.transform.position = upDetector.transform.position + new Vector3(0, 1, 0);
                }
            }
            if (detectionDirection == "left")
            {
                i--; //Move left to check if it should light
                x--;
                upDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                rightDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                downDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                leftDetector.transform.position = upDetector.transform.position + new Vector3(-1, 0, 0);
                if (windController.GetComponent<Wind>().windDirection > 5)
                {
                    windFactor = -1;
                }
                else if (windController.GetComponent<Wind>().windDirection > 1 && windController.GetComponent<Wind>().windDirection < 5)
                {
                    windFactor = 3;
                }
                else
                {
                    windFactor = 0;
                }
                reset = false;
                if (x == -25.5)
                {
                    reset = true;
                    detectionDirection = "up";
                    spreadTimer = 0;
                    i++;
                    x++;
                    upDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                    rightDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                    downDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                    leftDetector.transform.position = upDetector.transform.position + new Vector3(1, 0, 0);
                    upDetector.GetComponent<WaterDetector>().enabled = false;
                    leftDetector.GetComponent<WaterDetector>().enabled = false;
                    downDetector.GetComponent<WaterDetector>().enabled = false;
                    rightDetector.GetComponent<WaterDetector>().enabled = false;
                }
            }

            if (detectionTimer > .05 && detected && spreadTimer > 3)
            {
                if (detectionDirection == "up")
                {
                    FireCheck();
                    i = i + 50;
                    y--;
                    reset = true;
                    detectionDirection = "right";
                    detected = false;
                    detectionTimerGoing = false;
                }
                else if (detectionDirection == "right")
                {
                    FireCheck();
                    i--;
                    x--;
                    reset = true;
                    detectionDirection = "down";
                    detected = false;
                    detectionTimerGoing = false;
                }
                else if (detectionDirection == "down")
                {
                    FireCheck();
                    i = i - 50;
                    y++;
                    reset = true;
                    detectionDirection = "left";
                    detected = false;
                    detectionTimerGoing = false;
                }
                else
                {
                    FireCheck();
                    i++;
                    x++;
                    reset = true;
                    detectionDirection = "up";
                    detected = false;
                    detectionTimerGoing = false;
                    spreadTimer = 0;
                    upDetector.GetComponent<WaterDetector>().enabled = false;
                    leftDetector.GetComponent<WaterDetector>().enabled = false;
                    downDetector.GetComponent<WaterDetector>().enabled = false;
                    rightDetector.GetComponent<WaterDetector>().enabled = false;
                }
            }
            else if (detectionTimerGoing == false)
            {
                detectionTimerGoing = true;
                detected = false;
                upDetector.GetComponent<WaterDetector>().enabled = true;
                leftDetector.GetComponent<WaterDetector>().enabled = true;
                downDetector.GetComponent<WaterDetector>().enabled = true;
                rightDetector.GetComponent<WaterDetector>().enabled = true;
            }
            if (reset == false)
            {
                if (detectionDirection == "up")
                {
                    i = i + 50;
                    y--;
                }
                else if (detectionDirection == "right")
                {
                    i--;
                    x--;
                }
                else if (detectionDirection == "down")
                {
                    i = i - 50;
                    y++;
                }
                else
                {
                    i++;
                    x++;
                }
            }
            upDetector.transform.position = transform.position + new Vector3(1, 0, 0);
            rightDetector.transform.position = transform.position + new Vector3(0, 1, 0);
            downDetector.transform.position = transform.position + new Vector3(0, -1, 0);
            leftDetector.transform.position = transform.position + new Vector3(-1, 0, 0);
        }
        if (dieTimer > 30)
        {
            if (rnd.Next(1, 3) == 1)
            {
                mapGenerator.GetComponent<MapGenerator>().tiles[i] = 60;
                Instantiate(ashPrefab, new Vector3(x, y, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            dieTimer = 0;
        }
    }

    void FireCheck()
    {
        if (upDetector.GetComponent<WaterDetector>().detect == true || rightDetector.GetComponent<WaterDetector>().detect == true || downDetector.GetComponent<WaterDetector>().detect == true || leftDetector.GetComponent<WaterDetector>().detect == true)
        {
            if (mapGenerator.GetComponent<MapGenerator>().tiles[i] == 10 && rnd.Next(1, 7 + windFactor) == 1)
            {
                Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
                mapGenerator.GetComponent<MapGenerator>().tiles[i] = 50;
            }
            else if (mapGenerator.GetComponent<MapGenerator>().tiles[i] == 20 && rnd.Next(1, 8 + windFactor) == 1)
            {
                Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
                mapGenerator.GetComponent<MapGenerator>().tiles[i] = 50;
            }
            else if (mapGenerator.GetComponent<MapGenerator>().tiles[i] == 30 && rnd.Next(1, 9 + windFactor) == 1)
            {
                Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
                mapGenerator.GetComponent<MapGenerator>().tiles[i] = 50;
            }
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[i] == 10 && rnd.Next(1, 5 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[i] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[i] == 20 && rnd.Next(1, 6 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[i] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[i] == 30 && rnd.Next(1, 7 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[i] = 50;
        }
    }
}
