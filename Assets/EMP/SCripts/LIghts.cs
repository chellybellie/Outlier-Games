using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{


    public void LightShutdown()
    {
        GameObject[] LightSource = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject tgo in LightSource)
            tgo.GetComponent<Light>().enabled = false;
    }


    public void LightSwitchOn()
    {
        GameObject[] LightSource = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject tgo in LightSource)
            tgo.GetComponent<Light>().enabled = true;
    }


}


