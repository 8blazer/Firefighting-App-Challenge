using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject fieldPrefab;
    public GameObject housePrefab;
    public GameObject waterPrefab;
    public GameObject firePrefab;

    int i = 0;
    int trees = 0;
    int fields = 0;
    int houses = 0;
    int lakes = 0;
    System.Random rnd = new System.Random();
    public List<int> tiles = new List<int>();
    List<int> edges = new List<int>();
    List<int> possibilities = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        while (i < 2500)
        {
            tiles.Add(0);
            i++;
        }

        i = 0;
        while (i < 2600)
        {
            edges.Add(i);
            i = i + 50;
        }
        i = 49;
        while (i < 2600)
        {
            edges.Add(i);
            i = i + 50;
        }
        int generatorInt = 0;
        while (generatorInt < 3)
        {
            i = rnd.Next(0, 2500);
            while (tiles[i] != 0 && tiles.Contains(0))
            {
                i = rnd.Next(0, 2500);
            }
            tiles[i] = 1; //Fields
            while (tiles[i] != 0 && tiles.Contains(0))
            {
                i = rnd.Next(0, 2500);
            }
            tiles[i] = 2; //Forest
            while (tiles[i] != 0 && tiles.Contains(0))
            {
                i = rnd.Next(0, 2500);
            }
            tiles[i] = 4; //Lake
            trees = 0;
            fields = 0;
            houses = 0;
            lakes = 0;
            if (generatorInt < 2)
            {
                i = rnd.Next(103, 2297);
                tiles[i] = 3; //House
            }
            generatorInt++;
            while (tiles.Contains(3))
            {
                i = 0;
                possibilities.Clear();
                while (i < 2500)
                {
                    if (tiles[i] == 3)
                    {
                        possibilities.Add(i);
                    }
                    i++;
                }
                if (possibilities.Count > 1)
                {
                    i = possibilities[rnd.Next(0, possibilities.Count)];
                }
                else
                {
                    i = possibilities[0];
                }
                if (i > 49 /* top */ && i < 2450 /* bottom */ && !edges.Contains(i))
                {
                    if (tiles[i + 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(houses / 10) + 1) < 6)
                    {
                        tiles[i + 1] = 3;
                        houses++;
                    }
                    if (tiles[i - 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(houses / 10) + 1) < 6)
                    {
                        tiles[i - 1] = 3;
                        houses++;
                    }
                    if (tiles[i + 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(houses / 10) + 1) < 6)
                    {
                        tiles[i + 50] = 3;
                        houses++;
                    }
                    if (tiles[i - 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(houses / 10) + 1) < 6)
                    {
                        tiles[i - 50] = 3;
                        houses++;
                    }
                }
                tiles[i] = 30;
            }
            while (tiles.Contains(4))
            {
                i = 0;
                possibilities.Clear();
                while (i < 2500)
                {
                    if (tiles[i] == 4)
                    {
                        possibilities.Add(i);
                    }
                    i++;
                }
                if (possibilities.Count > 1)
                {
                    i = possibilities[rnd.Next(0, possibilities.Count)];
                }
                else
                {
                    i = possibilities[0];
                }
                if (i > 49 /* top */ && i < 2450 /* bottom */ && !edges.Contains(i))
                {
                    if (tiles[i + 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(lakes / 10) + 1) < 5)
                    {
                        tiles[i + 1] = 4;
                        lakes++;
                    }
                    if (tiles[i - 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(lakes / 10) + 1) < 5)
                    {
                        tiles[i - 1] = 4;
                        lakes++;
                    }
                    if (tiles[i + 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(lakes / 10) + 1) < 5)
                    {
                        tiles[i + 50] = 4;
                        lakes++;
                    }
                    if (tiles[i - 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(lakes / 10) + 1) < 5)
                    {
                        tiles[i - 50] = 4;
                        lakes++;
                    }
                }
                tiles[i] = 40;
            }
            while (tiles.Contains(2))
            {
                i = 0;
                possibilities.Clear();
                while (i < 2500)
                {
                    if (tiles[i] == 2)
                    {
                        possibilities.Add(i);
                    }
                    i++;
                }
                if (possibilities.Count > 1)
                {
                    i = possibilities[rnd.Next(0, possibilities.Count)];
                }
                else
                {
                    i = possibilities[0];
                }
                if (i > 49 /* top */ && i < 2450 /* bottom */ && !edges.Contains(i))
                {
                    if (tiles[i + 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(trees / 10) + 1) < 8)
                    {
                        tiles[i + 1] = 2;
                        trees++;
                    }
                    if (tiles[i - 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(trees / 10) + 1) < 8)
                    {
                        tiles[i - 1] = 2;
                        trees++;
                    }
                    if (tiles[i + 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(trees / 10) + 1) < 8)
                    {
                        tiles[i + 50] = 2;
                        trees++;
                    }
                    if (tiles[i - 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(trees / 10) + 1) < 8)
                    {
                        tiles[i - 50] = 2;
                        trees++;
                    }
                }
                tiles[i] = 20;
            }
            while (tiles.Contains(1))
            {
                i = 0;
                possibilities.Clear();
                while (i < 2500)
                {
                    if (tiles[i] == 1)
                    {
                        possibilities.Add(i);
                    }
                    i++;
                }
                if (possibilities.Count > 1)
                {
                    i = possibilities[rnd.Next(0, possibilities.Count)];
                }
                else
                {
                    i = possibilities[0];
                }
                if (i > 49 /* top */ && i < 2450 /* bottom */ && !edges.Contains(i))
                {
                    if (tiles[i + 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(fields / 10) + 1) < 8)
                    {
                        tiles[i + 1] = 1;
                        fields++;
                    }
                    if (tiles[i - 1] == 0 && rnd.Next(1, (int)Mathf.Ceil(fields / 10) + 1) < 8)
                    {
                        tiles[i - 1] = 1;
                        fields++;
                    }
                    if (tiles[i + 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(fields / 10) + 1) < 8)
                    {
                        tiles[i + 50] = 1;
                        fields++;
                    }
                    if (tiles[i - 50] == 0 && rnd.Next(1, (int)Mathf.Ceil(fields / 10) + 1) < 8)
                    {
                        tiles[i - 50] = 1;
                        fields++;
                    }
                }
                tiles[i] = 10;
            }
        }

        i = rnd.Next(0, 2500);
        while (tiles[i] == 40 || tiles[i] == 30)
        {
            i = rnd.Next(0, 2500);
        }
        tiles[i] = 50;

        i = 0;
        int i2 = 0;
        
        while (tiles.Contains(0))
        {
            if (tiles[i] == 0)
            {
                i2 = rnd.Next(1, 91);
                if (i2 < 51)
                {
                    tiles[i] = 10;
                }
                else if (i2 > 50 && i2 < 81)
                {
                    tiles[i] = 20;
                }
                else if (i2 > 80 && i2 < 89)
                {
                    tiles[i] = 30;
                }
                else
                {
                    tiles[i] = 40;
                }
                if (tiles[i] > 49 && tiles[i] < 2451)
                {
                    if (tiles[i + 1] == 4 || tiles[i - 1] == 4 || tiles[i + 50] == 4 || tiles[i - 50] == 4)
                    {
                        tiles[i] = 40;
                    }
                }
            }
            i++;
        }
        i = 0;
        float x = -24.5f;
        float y = 24.5f;
        while (i < 2500) //Generates the tiles
        {
            if (tiles[i] == 10)
            {
                Instantiate(fieldPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (tiles[i] == 20)
            {
                Instantiate(treePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (tiles[i] == 30)
            {
                Instantiate(housePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
            else if (tiles[i] == 40)
            {
                Instantiate(waterPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(firePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
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
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
