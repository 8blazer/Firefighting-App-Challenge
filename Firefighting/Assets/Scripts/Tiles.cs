using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{
    public int position;
    GameObject mapGenerator;
    GameObject canvas;
    float x = -24.5f;
    float y = 24.5f;
    public Text textPrefab;

    void Start()
    {
        mapGenerator = GameObject.Find("MapGenerator");
        canvas = GameObject.Find("Canvas");
        while (x != transform.position.x || y != transform.position.y) //Find where this tile is
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
            position++;
        }
    }

    void Update()
    {
        if (mapGenerator.GetComponent<MapGenerator>().tiles[position] == 50 || mapGenerator.GetComponent<MapGenerator>().tiles[position] == 60)
        {
            Destroy(gameObject);
        }
    }
}
