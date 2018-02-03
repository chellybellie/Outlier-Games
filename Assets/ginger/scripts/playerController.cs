using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class playerController : MonoBehaviour
{
    
    public GameObject pausemenu;
    public GameObject buttonpanel;
    public float speed = 20f;
    public Camera cam;

    public int health = 100;

    
    public void Pause()
    {
        pausemenu.SetActive(true);
        buttonpanel.SetActive(true);
        Time.timeScale = 0;
    }

    
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }
    void OnTriggerEnter(Collider col)
    {
        health -= 10;
        if(health < 10)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}