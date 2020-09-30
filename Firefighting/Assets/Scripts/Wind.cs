using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int windDirection;
    System.Random rnd = new System.Random();
    float timer = 0;
    public Sprite up;
    public Sprite upRight;
    public Sprite right;
    public Sprite downRight;
    public Sprite down;
    public Sprite downLeft;
    public Sprite left;
    public Sprite upLeft;
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
        if (timer > 30)
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
        switch (windDirection)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = up;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = upRight;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = right;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = downRight;
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = down;
                break;
            case 6:
                gameObject.GetComponent<SpriteRenderer>().sprite = downLeft;
                break;
            case 7:
                gameObject.GetComponent<SpriteRenderer>().sprite = left;
                break;
            case 8:
                gameObject.GetComponent<SpriteRenderer>().sprite = upLeft;
                break;
        }
    }
}
