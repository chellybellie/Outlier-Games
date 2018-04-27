using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perm_Light_Flicker : MonoBehaviour
{

    Light l;
    public float intense;
    float fs;


    void Start ()
    {
        l = gameObject.GetComponent<Light>();

        if (l != null)
            l.intensity = 0;
    }
	
	
	void Update ()
    {

    
        if (l != null)
        {

            //flickerTime += Time.deltaTime;
            fs -= Time.deltaTime;
            if ( fs <= 0)
            {
                if (l.intensity == 0)
                {
                    l.intensity = intense;
                }
                else
                {
                    l.intensity = 0;
                }

                fs = Random.Range(.03f, .3f);
            }
        }
    }
}
