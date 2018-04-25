using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoCount : MonoBehaviour {

    public float count;
    Text txt;
	void Start () {
        txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = count.ToString();
	}
}
