using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    public Animator anim;
    bool doorOpen;
    bool doorClosed;
	void Start ()
    {
        doorOpen = false;
        //anim = GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            doorOpen = true;
            doorClosed = false;
            anim.Play("DoorOpen");
        }
        if (col.gameObject.CompareTag("enemy"))
        {
            doorClosed = false;
            doorOpen = true;
            anim.Play("DoorOpen");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            doorClosed = true;
            doorOpen = false;
            anim.Play("DoorClose");
        }
        if (col.gameObject.CompareTag("enemy"))
        {
            doorOpen = false;
            doorClosed = true;
            anim.Play("DoorClose");
        }
    }

}
