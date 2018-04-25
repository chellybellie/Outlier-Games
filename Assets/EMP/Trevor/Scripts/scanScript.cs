using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scanScript : MonoBehaviour {

    public float scanHP;
    public string scanName;

    public Image scanHPImage;
    public Text scanNameText;

    public bool scan;
	void Start () {
        scanHP = 0;
        scanName = "";
	}
	
	// Update is called once per frame
	void Update () {
        scanHPImage.fillAmount = scanHP / 100;
        scanNameText.text = scanName;
	}

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("ding");

        if(other.gameObject.tag == "scan")
        {
            scan = true;
            scanHP = other.gameObject.GetComponent<stats>().hp;
            scanName = other.gameObject.GetComponent<stats>().crewName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "scan")
        {
            scan = false;
            scanHP = 0;
            scanName = "";
        }
    }
}
