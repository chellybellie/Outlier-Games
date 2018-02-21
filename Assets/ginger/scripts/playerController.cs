using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public class playerController : MonoBehaviour
{
    
    public GameObject pausemenu;
    public GameObject buttonpanel;
    float speed = 4f;
    public Camera cam;
    public Vector2 move;
    public GameObject healthpk;

    public int health = 100;
    void Start()
    {
        move = Vector2.zero;
    }
    
    public void Pause()
    {
        pausemenu.SetActive(true);
        buttonpanel.SetActive(true);
        Time.timeScale = 0;
    }

   
    void Update()
    {

        if(Input.GetKey(KeyCode.W))
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
            Pause();
        }
        move *= .7f;

        if (health < 10)
        {
            SceneManager.LoadScene(2);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("enemy"))
        {
            health -= 10;
        }
        if(col.gameObject.CompareTag("health") && health < 100)
        {
            health += 10;
            Destroy(healthpk);
        }     
        
    }
}