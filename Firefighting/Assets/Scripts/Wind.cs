using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int windDirection;
    System.Random rnd = new System.Random();
    float timer = 0;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        windDirection = rnd.Next(1, 9); //1 is up, 2 is up-right, 3 is right, etc.
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 60)
        {
            i = rnd.Next(1, 4);
            if (i == 1)
            {
                if (windDirection == 8)
                {
                    windDirection = 1;
                }
                else
                {
                    windDirection++;
                }
            }
            else if (i == 2)
            {
                if (windDirection == 1)
                {
                    windDirection = 8;
                }
                else
                {
                    windDirection--;
                }
            }
            timer = 0;
        }
    }
}
