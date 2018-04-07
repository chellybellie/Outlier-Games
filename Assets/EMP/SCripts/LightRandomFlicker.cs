using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandomFlicker : MonoBehaviour
{


    Light light;
    public float minFlickerSpeed;
    public float maxFlickerSpeed;
    public float minLightIntensity;
    public float maxLightIntensity; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		while (true)
        {
            light.enabled = true;
            light.intensity = Random.Range(minLightIntensity, maxLightIntensity);
           
        }
	}
}
