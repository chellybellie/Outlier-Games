﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorController : MonoBehaviour {
    public Animator anim;
    public NavMeshObstacle navMeshObstacle;
    bool doorOpen;
    bool doorClosed;
    public float doorLevel;

	void Start ()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        doorOpen = false;
        anim = GetComponent<Animator>();
	}
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            if (col.gameObject.GetComponent<playerController>().keyLevel >= doorLevel)
            {
                navMeshObstacle.carving = false;
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
            navMeshObstacle.carving = true;
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
