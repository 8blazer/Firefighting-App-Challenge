using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    float x = -24.5f;
    float y = 24.5f;
    int i = 0;
    int position;
    float spreadTimer;
    float dieTimer;
    GameObject mapGenerator;
    GameObject windController;
    public GameObject firePrefab;
    public GameObject ashPrefab;
    int windFactor;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        mapGenerator = GameObject.Find("MapGenerator");
        windController = GameObject.Find("WindController");
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
        spreadTimer += Time.deltaTime;
        dieTimer += Time.deltaTime;
        if (spreadTimer > 1)
        {
            if (transform.position.x != 24.5f && mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] < 40)
            {
                FireRight();
            }
            if (transform.position.x != -24.5f && mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] < 40)
            {
                FireLeft();
            }
            if (transform.position.y != 24.5f && mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] < 40)
            {
                FireUp();
            }
            if (transform.position.y != -24.5f && mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] < 40)
            {
                FireDown();
            }
            spreadTimer = 0;
        }
        if (dieTimer > 30)
        {
            if (rnd.Next(1, 3) == 1)
            {
                mapGenerator.GetComponent<MapGenerator>().tiles[position] = 60;
                Instantiate(ashPrefab, new Vector3(x, y, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            dieTimer = 0;
        }
    }

    void FireRight()
    {
        if (windController.GetComponent<Wind>().windDirection > 1 && windController.GetComponent<Wind>().windDirection < 5)
        {
            windFactor = -10;
        }
        else if (windController.GetComponent<Wind>().windDirection > 5)
        {
            windFactor = 25;
        }
        else
        {
            windFactor = 0;
        }
        if (mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] == 10 && rnd.Next(1, 35 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x + 1, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] == 20 && rnd.Next(1, 40 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x + 1, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] == 30 && rnd.Next(1, 45 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x + 1, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position + 1] = 50;
        }
    }

    void FireLeft()
    {
        if (windController.GetComponent<Wind>().windDirection > 5)
        {
            windFactor = -10;
        }
        else if (windController.GetComponent<Wind>().windDirection > 1 && windController.GetComponent<Wind>().windDirection < 5)
        {
            windFactor = 25;
        }
        else
        {
            windFactor = 0;
        }
        if (mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] == 10 && rnd.Next(1, 35 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x - 1, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] == 20 && rnd.Next(1, 40 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x - 1, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] == 30 && rnd.Next(1, 45 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x - 1, y, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position - 1] = 50;
        }
    }

    void FireUp()
    {
        if (windController.GetComponent<Wind>().windDirection < 3 || windController.GetComponent<Wind>().windDirection == 8)
        {
            windFactor = -10;
        }
        else if (windController.GetComponent<Wind>().windDirection > 3 && windController.GetComponent<Wind>().windDirection < 7)
        {
            windFactor = 25;
        }
        else
        {
            windFactor = 0;
        }
        if (mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] == 10 && rnd.Next(1, 35 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y + 1, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] == 20 && rnd.Next(1, 40 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y + 1, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] == 30 && rnd.Next(1, 45 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y + 1, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position - 50] = 50;
        }
    }

    void FireDown()
    {
        if (windController.GetComponent<Wind>().windDirection < 7 || windController.GetComponent<Wind>().windDirection > 3)
        {
            windFactor = -10;
        }
        else if (windController.GetComponent<Wind>().windDirection < 3 || windController.GetComponent<Wind>().windDirection == 8)
        {
            windFactor = 25;
        }
        else
        {
            windFactor = 0;
        }
        if (mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] == 10 && rnd.Next(1, 35 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y - 1, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] == 20 && rnd.Next(1, 40 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y - 1, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] = 50;
        }
        else if (mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] == 30 && rnd.Next(1, 45 + windFactor) == 1)
        {
            Instantiate(firePrefab, new Vector3(x, y - 1, 0), Quaternion.identity);
            mapGenerator.GetComponent<MapGenerator>().tiles[position + 50] = 50;
        }
    }
}
