using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perm_Light_Flicker : MonoBehaviour
{

    Light l;
    TubeLight tl;
    AreaLight al;
    public float intense;
    float fs;


    void Start ()
    {
        l = gameObject.GetComponent<Light>();
        tl = gameObject.GetComponent<TubeLight>();
        al = gameObject.GetComponent<AreaLight>();

        if (l != null)
            l.intensity = 0;
        if (tl != null)
            tl.m_Intensity = 0;
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

        if (tl != null)
        {

           
            fs -= Time.deltaTime;
            if ( fs <= 0)
            {

                if (tl.m_Intensity == 0)
                {
                    tl.m_Intensity = intense;
                }
                else
                {
                    tl.m_Intensity = 0;
                }

                fs = Random.Range(.03f, .4f);
            }

        }


        if (al != null)
        {

            fs -= Time.deltaTime;
            if (fs <= 0)
            {

                if (al.m_Intensity == 0)
                {
                    al.m_Intensity = intense;
                }
                else
                {
                    al.m_Intensity = 0;
                }

                fs = Random.Range(.05f, .25f);

            }
            
        }

    }
}
