using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);

        if(gameObject.transform.position.y > 2500)
        {
            Destroy(gameObject);
        }
	}
}
