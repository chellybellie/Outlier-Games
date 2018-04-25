using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlickerScript : MonoBehaviour
{

    Light l;
    public float range;
    GameObject camPos;
    public float flickerTime;
    public float intense;
    float fs;
    bool on;
    // Use this for initialization
    void Start()
    {
        l = gameObject.GetComponent<Light>();
        
        l.intensity = 0;
        camPos = Camera.main.gameObject;
        flickerTime = 0;
        fs = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(camPos.transform.position, transform.position) < range)
        {
            on = true;
        }

        if (on)
        {
            flickerTime += Time.deltaTime;
            fs -= Time.deltaTime;
            if((flickerTime < 1.5f) && fs <= 0)
            {
                if(l.intensity == 0)
                {
                    l.intensity = intense;
                }
                else
                {
                    l.intensity = 0;
                }

                fs = Random.Range(.05f, .25f);
            }
            if(flickerTime > 2)
            {
                l.intensity = intense;
            }
        }
        else
        {
            flickerTime = 0;
        }
    }

}
