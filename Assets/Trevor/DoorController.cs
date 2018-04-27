using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    public Animator anim;
    bool doorOpen;
    bool doorClosed;
    public float doorLevel;
	void Start ()
    {
        
        doorOpen = false;
        //anim = GetComponent<Animator>();
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space)) 
        {
            if(col.gameObject.GetComponent<playerController>().keyLevel >= doorLevel)
            {
                doorOpen = true;
                doorClosed = false;
                anim.Play("DoorOpen");
            }
            
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
            if(doorOpen)
            {
                anim.Play("DoorClose");
            }

            doorClosed = true;
            doorOpen = false;
            
        }
        if (col.gameObject.CompareTag("enemy"))
        {

            if (doorOpen)
            {
                anim.Play("DoorClose");
            }

            doorOpen = false;
            doorClosed = true;
        }
    }

}
