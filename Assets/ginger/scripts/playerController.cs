using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[Serializable]
public class playerController : MonoBehaviour
{
    public HPScript hpscript;
    public GameObject pausemenu;
    float speed = 2f;
    public Camera cam;
    public Vector2 move;
    public stats enemy;
    public Weapons wep;
    public float keyLevel;
    public bool hasKeyOne, hasKeyTwo, hasKeyThree, hasKeyFour = false;
    public GameObject keyOne, keyTwo, keyThree, keyFour;
    public float health = 100;
 


    

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis


    void Start()
    {
        keyLevel = 0;
        move = Vector2.zero;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        keyOne.SetActive(false);
        keyTwo.SetActive(false);
        keyThree.SetActive(false);
        keyFour.SetActive(false);
    }



    public void Pause()
    {
        pausemenu.SetActive(true);

        Time.timeScale = 0;

        Time.timeScale = 0;
    }




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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        move *= .7f;

        if (health < 10)
        {
            SceneManager.LoadScene(2);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            hpscript.bleed = 10;
            hpscript.hit = 10;
            hpscript.bleedSeverity = 1;
            hpscript.bleedState = "Bleed 1";
            health -= 10;
            enemy.enemyanim.Play("attack");
            hpscript.hpBar.fillAmount = (health / 100);
            hpscript.bleedBar.fillAmount = (hpscript.bleedHP / 100);
        }
        if (col.gameObject.CompareTag("health") && health < 100)
        {
            health += 10;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene(3);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (col.gameObject.CompareTag("ammo"))
        {
            wep.ammo += 10;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("holoScan"))
        {
            return;
        }
        if (col.gameObject.CompareTag("keyOne"))
        {
            hasKeyOne = true;
            keyOne.SetActive(true);
            if (keyLevel < 1)
            {
                keyLevel = 1;
            }
             Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("keyTwo"))
        {
            hasKeyTwo = true;
            keyTwo.SetActive(true);
            if (keyLevel < 2)
            {
                keyLevel = 2;
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("keyThree"))
        {
            hasKeyThree = true;
            keyThree.SetActive(true);
            if (keyLevel < 3)
            {
                keyLevel = 3;
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("keyFour"))
        {
            hasKeyFour = true;
            keyFour.SetActive(true);
            if (keyLevel < 4)
            {
                keyLevel = 4;
            }
            Destroy(col.gameObject);
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