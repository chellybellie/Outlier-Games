using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghts : MonoBehaviour
{
    private int lights;

    void Start()
    {
    }

    public void LightShutdown()
    {
        GameObject[] LightSource = new GameObject[lights];

        for (int i = 0; i < lights; ++i)
        {
            LightSource[i] = GameObject.FindWithTag("Light" + i);
            LightSource[i].GetComponent<Light>().enabled = false;
            
           
        }
    }

    void Update()
    {
        LightShutdown();
    }
}


  