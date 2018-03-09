﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public class playerController : MonoBehaviour
{

    public GameObject pausemenu;
    float speed = 4f;
    public Camera cam;
    public Vector2 move;

     public float health = 100;

   

    public GameObject healthpk;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    void Start()
    {
        move = Vector2.zero;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }



    public void Pause()
    {
        pausemenu.SetActive(true);

        Time.timeScale = 0;
<<<<<<< HEAD
    }    
        
=======
    } 
>>>>>>> master




    void Update()
    {
        mouseRotate();

        if (Input.GetKey(KeyCode.W))
        {
            move.y += Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += Time.deltaTime * speed;
        }


        transform.Translate(move.x, 0, move.y);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
        Time.timeScale = 0;
        }
        move *= .7f;

        if (health < 10)
        {
            SceneManager.LoadScene(2);
        }
    }
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            health -= 10;
        }
        if (col.gameObject.CompareTag("health") && health < 100)
        {
            health += 10;
            Destroy(healthpk);
        }

    }

    public void mouseRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion playerRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        Quaternion camRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = playerRotation;
        cam.transform.rotation = camRotation;
    }
}