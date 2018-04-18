using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.Rendering.PostProcessing;

public class ExamplePPScript : MonoBehaviour {
    public PostProcessVolume ppv;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            ppv.enabled = true;

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
            ppv.enabled = false;
    }
}
