using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoRotate : MonoBehaviour {

    public GameObject img;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        img.transform.Rotate(new Vector3(0,1.5f,0));
	}

}
