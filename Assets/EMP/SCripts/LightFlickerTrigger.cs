using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerTrigger : MonoBehaviour
{
    Light l;
    AreaLight a;
    public float range;
    GameObject camPos;
    public float lightIntensity;
    public float LightOnSpeed;
    public EMP emp;
    Lights Light;
    // Use this for initialization
    void Start()
    {
        l = gameObject.GetComponent<Light>();
        a = gameObject.GetComponent<AreaLight>();

        camPos = Camera.main.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (l != null)
        {

            if (Vector3.Distance(emp.EMPTester.transform.position, Light.transform.position) < emp.radius)
            {
                if (l.intensity < lightIntensity)
                {
                    l.intensity += (lightIntensity / LightOnSpeed);
                }

            }
            else
            {
                l.intensity -= (lightIntensity / LightOnSpeed);
            }
        }
        else
        {
            if (Vector3.Distance(camPos.transform.position, transform.position) < range)
            {
                if (a.m_Intensity < lightIntensity)
                {
                    a.m_Intensity += (lightIntensity / LightOnSpeed);
                }
            }

            else
            {
                if (a.m_Intensity > 0)
                {
                    a.m_Intensity -= (lightIntensity / LightOnSpeed);
                }

            }
        }

    }

}