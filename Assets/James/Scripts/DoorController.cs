using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator Animator;
    public GameObject Door;
    public bool Open;

    void Start()
    {
        Open = false;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Open = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Open = false;
        }
    }
}
