using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFadeScript : MonoBehaviour {

    Light l;
    public float range;
    GameObject camPos;
	// Use this for initialization
	void Start () {
        l = gameObject.GetComponent<Light>();
        range = 5.0f;
        camPos = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if(Vector3.Distance(camPos.transform.position, transform.position) < range)
        {
            if(l.intensity < 3.3)
            {
                l.intensity += .1f;
            }
            
        }
        else
        {
            l.intensity -= .1f;
        }
	}
    
}
