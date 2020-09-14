using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDetector : MonoBehaviour
{
    public bool detect = false;
    GameObject fire;

    void Update()
    {
        if (fire == null)
        {
            fire = gameObject.transform.parent.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (fire != null)
        {
            if (collision.gameObject.tag == "Water")
            {
                detect = true;
            }
            fire.GetComponent<Fire>().detected = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (fire != null)
        {
            detect = false;
            fire.GetComponent<Fire>().detected = true;
        }
    }
}
