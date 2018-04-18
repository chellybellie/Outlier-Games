using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandomFlicker : MonoBehaviour
{
    Light l;
    AreaLight al;
    TubeLight tl;
    Renderer s;
    public float range;
    GameObject camPos;
    public float flickerTime;
    public float intense;
    float fs;
    public bool on;
    // Use this for initialization
    void Start()
    {
        l = gameObject.GetComponent<Light>();
        al = gameObject.GetComponent<AreaLight>();
        tl = gameObject.GetComponent<TubeLight>();
        s = gameObject.GetComponent<Renderer>();
        if(l != null)
        l.intensity = 0;
        if(al != null)
        al.m_Intensity = 0;
        if (tl != null)
        tl.m_Intensity = 0;
        
            

       camPos = Camera.main.gameObject;
        flickerTime = 0;
        fs = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Vector3.Distance(camPos.transform.position, transform.position) < range)
        //{
        //    on = true;
        //}

        if ( l != null)
        {
            flickerTime += Time.deltaTime;
            fs -= Time.deltaTime;
            if ((flickerTime < 1.5f) && fs <= 0)
            {
                if (l.intensity == 0)
                {
                    l.intensity = intense;
                }
                else
                {
                    l.intensity = 0;
                }

                fs = Random.Range(.05f, .25f);
            }
            if (flickerTime > 2)
            {
                l.intensity = intense;
                on = true;
            }
            if (on == true)
            {
                flickerTime = 3;
            }
        }

    


            if ( al != null)
        {
            flickerTime += Time.deltaTime;
            fs -= Time.deltaTime;
            if ((flickerTime< 1.5f) && fs <= 0)
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
            if (flickerTime > 2)
            {
                al.m_Intensity = intense;
                on = true;
            }
            if(on == true)
            {
                flickerTime = 3;
            }
        }

            


        if (tl != null)
        {
            flickerTime += Time.deltaTime;
            fs -= Time.deltaTime;
            if ((flickerTime < 1.5f) && fs <= 0)
            {
                if (tl.m_Intensity == 0)
                {
                    tl.m_Intensity = intense;
                }
                else
                {
                    tl.m_Intensity = 0;
                }

                fs = Random.Range(.05f, .25f);
            }
            if (flickerTime > 2)
            {
                tl.m_Intensity = intense;
                on = true;
            }
            if (on == true)
            {
                flickerTime = 3;
            }
        }

        if (s != null)
        {
            flickerTime += Time.deltaTime;
            fs -= Time.deltaTime;
            if ((flickerTime < 1.5f) && fs <= 0)
            {
                if (s)
                {
                    s.m_Intensity = intense;
                }
                else
                {
                    s.m_Intensity = 0;
                }

                fs = Random.Range(.05f, .25f);
            }
            if (flickerTime > 2)
            {
                s.m_Intensity = intense;
                on = true;
            }
            if (on == true)
            {
                flickerTime = 3;
            }
        }

    }
    }


